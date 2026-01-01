# API de Biblioteca

API sencilla desarrollada en **.NET + Entity Framework Core** que gestiona tres entidades principales:

- **Libros**
- **Autores**
- **Comentarios**

<img width="1315" height="300" alt="Captura de pantalla 2026-01-01 074024" src="https://github.com/user-attachments/assets/862aaecf-87fa-4473-a1fc-369cdac5e3e8" />

<img width="1324" height="300" alt="Captura de pantalla 2026-01-01 074115" src="https://github.com/user-attachments/assets/b0dd4a08-7a06-477e-b77c-bcb8da573f59" />

<img width="1320" height="229" alt="Captura de pantalla 2026-01-01 074054" src="https://github.com/user-attachments/assets/94e0916e-49cc-4d5f-ab73-53c034aa875b" />

Cada entidad cuenta con endpoints REST para:
- `GET` → obtener todos los registros o uno por `id`.
- `POST` → crear un nuevo registro (requiere autenticación).
- `PUT` → actualizar un registro existente (requiere autenticación).

---

### Requisitos previos

- [Visual Studio 2022](https://visualstudio.microsoft.com/)
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server

---

### Autenticación y uso de token

Los endpoints `POST` y `PUT` están protegidos y requieren autenticación mediante **JWT (JSON Web Token)**.  

1. **Registro de usuario o Inicio de sesión**
2. **Uso del token generado como respuesta** 

<img width="1329" height="227" alt="Captura de pantalla 2026-01-01 074148" src="https://github.com/user-attachments/assets/c248bd13-33d1-4d2b-b7e6-07ccb18aeb34" />

<img width="1323" height="345" alt="Captura de pantalla 2026-01-01 074234" src="https://github.com/user-attachments/assets/39f5a460-aa9a-4110-908a-7fd94ab63bb4" />

**Nota:** el endpoint Api/Usuarios no se usa, el de Api/Usuarios/registro o Api/Usuarios/login son con los que hay que hacer la peticion para obtener el token

### Nota sobre la base de datos

La aplicación fue desarrollada en **Visual Studio** utilizando **Entity Framework Core**.  
Para inicializar la base de datos es necesario aplicar las migraciones incluidas en el proyecto.

1. Abrir la **Consola del Administrador de Paquetes** en Visual Studio
2. Ejecutar el siguiente comando: **Update-Database**

