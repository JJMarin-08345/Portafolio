ESTE PROYECTO ESTÁ REALIZADO CON NET VERSION 6.0.0 ORIGINALMENTE PERO SE CAMBIO A 8.0

1. Estar ubicado dentro de la carpeta aplicación y hacer las siguientes instalaciones:
    - dotnet tool install --global dotnet-ef
    - dotnet tool update --global dotnet-ef (opcional)

2. En las carpetas Consola y Frontend instalar lo siguiente:
    - dotnet add package Microsoft.EntityFrameworkCore
    - dotnet add package Microsoft.EntityFrameworkCore.Tools
    - dotnet add package Microsoft.EntityFrameworkCore.Design
    - dotnet add package Microsoft.EntityFrameworkCore.SqlServer

3. Para la BD se usa SQL SERVER:
    - En eb SQL SERVER debemos crear una base de datos llamada asi: BDEscenarioDeportiva 
      (sin tablas ni nada, solo la BD)

    - En el AppContext (que está dentro de la carpeta Persistencia) en el metodo que sobreescribimos (OnConfiguring) 
      en el _"Server"_, debemos poner el server name que aparece en nuestro SQL SERVER

    - De ahí debemos (dentro de la carpeta Persistencia) poner el siguiente comando:
      dotnet ef migrations add SubidaBD

    - Luego, hacemos el update a la BD con el siguiente comando:
      dotnet ef database update

    - Igual, en el archivo AppContext está los comandos para que se suban las entidades con sus relaciones a la BD