using APIBiblioteca.Entidades.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace APIBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private UserManager<IdentityUser> user;
        private IConfiguration Configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public UsuariosController(UserManager<IdentityUser> userManager, IConfiguration configuration,
                                    SignInManager<IdentityUser> signInManager)
        {
            user = userManager;
            Configuration = configuration;
            this.signInManager = signInManager;
        }

        [HttpPost("registro")]
        public async Task<ActionResult> Registrar(CredencialesUsuarioDTO credencialesUsuarioDTO)
        {
            var usuario = new IdentityUser
            {
                UserName = credencialesUsuarioDTO.Email,
                Email = credencialesUsuarioDTO.Email
            };

            var resultado = await user.CreateAsync(usuario, credencialesUsuarioDTO.Password);

            if (resultado.Succeeded)
            {

                return Ok(await ConstruirToken(credencialesUsuarioDTO));
            }
            else
            {
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
                return ValidationProblem();
            }
        }


        public async Task<RespuestaAutenticacionDTO> ConstruirToken(CredencialesUsuarioDTO credencialesUsuarioDTO)
        {
            var claims = new List<Claim>
            {
                new Claim("email", credencialesUsuarioDTO.Email)
            };

            var usuario = await user.FindByEmailAsync(credencialesUsuarioDTO.Email);
            var claimsDB = await user.GetClaimsAsync(usuario);
            claims.AddRange(claimsDB);

            var llave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Configuration["llavejwt"]));

            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var experacion = DateTime.UtcNow.AddMinutes(15);
            var tokenSeguridad = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: experacion, signingCredentials: creds);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenSeguridad);


            return new RespuestaAutenticacionDTO
            {
                Token = token,
                Expiracion = experacion
            };

        }


        //Login de usuarios

        [HttpPost("login")]
        public async Task<ActionResult> Login(CredencialesUsuarioDTO credencialesUsuarioDTO)
        {

            var usuario = await user.FindByEmailAsync(credencialesUsuarioDTO.Email);
            if (usuario == null)
            {
                return Unauthorized();
            }

            var resultado = await signInManager.CheckPasswordSignInAsync(usuario,
                credencialesUsuarioDTO.Password, false);

            if (resultado.Succeeded)
            {
                return Ok(await ConstruirToken(credencialesUsuarioDTO));
            }
            else
            {
                return Unauthorized();

            }

        }
    }
}
