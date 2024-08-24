# README del Proyecto

Este README proporciona instrucciones sobre cómo ejecutar el proyecto localmente y cómo desplegarlo en Azure.

## Ejecución Local

### 1. Clonar el Repositorio

Descarga el proyecto desde el repositorio Git.

### 2. Configuración de la Base de Datos

Modifica el nombre de tu instancia local SQL Server en el archivo `appsettings.json`.

### 3. Ejecutar Migraciones

Abrir el proyecto en el IDE d epreferencia y ejecutar or consola:

```bash
update-database-context TareaDbContext
```

### 4. Ejecutar el proyecto

## Desplegar a Azure

### 1. Crear suscripción Azure
- Crear una suscripción de [Azure](https://portal.azure.com/)
- La suscripción puede ser una versión de prueba
### 2. Crear recurso para Web App
- Dar click en crear recurso.
​- Seleccionar Web App.
-​ Crear un resource group, en caso de ni existir.
​- Seleccionar una región, sistema operativo, nombre del proyecto y habilitar el acceso público. Y dar click en crear.
### 3. Configurar proyecto desde Visual Studio
- abrir la solución en Visual Studio 
- dar click derecho al proyecto
- seleccionar publicar
- Seleccionar Azure
- Seleccionar Azure App Service Windows
- Elegir la suscripcion creada anteriormente.
### 4. Configurar base de Datos SQL Server
Primero debemos asegurarnos que exista un usuario con permisos de administrador en nuestra instancia de base de datos local.
- Desde Visual Studio, en la misma ventana donde se realiza la configuración para publicar el proyecto agregamos una base de datos Azuere SQL Server con el botón de agregar conexión.
- Debemos especificar el nombre de la base de datos, el usuario y la contraseña (usuario con permisos de login).
### 5. Agregar IP a Firewall de Azure
- Desde el portal de Azure en la configuración del recurso de base de datos agregamos nuestra dirección **ip pública** para poder conectarnos.
### 6. Conectarnos de manera local a la BD
- Copiar el nombre del servidor desde el portal de Azure.
- Iniciar sesión de Visual Studio Management Studion con ese nombre del servidor, usuario y contraseña de nuestro usuario creado anteriormente.
### 7. Crear tablas de la BD con .NET
En la consola de .Net o Visual Studio ejecutamos
```bash
update-database-context TareaDbContext
```
Las tablas son creadas y nuestro proyecto estará listo para ser utilizado de manera pública.

