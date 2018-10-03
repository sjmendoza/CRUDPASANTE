# CrudPasante
Proyecto en .NET C#, asp.net con SQL Server
El programa fue trabajado en el IDE Visual Studio. 
El ejecutable no funcionara si no existe una base en SQL Server.

1. Descarga carpeta y descomprimir
2. Abrir Visual Studio y buscar la carpeta ya descomprimida.
3. Dentro de Visual Studio, en el explorador de soluciones dar click a Prueba.sln
4. En SQL Server crear una base Prueba con una tabla pasante, la cual el sql esta dado en el proyecto en la 
carpeta llamada Base.
6. Regresemos a Visual Studio y cambiar la linea 18 de la Clase "Conexion": 
conector = new SqlConnection("Data Source = MENDOZA; Initial Catalog = Prueba; Integrated Security = True");
en Data Source cambiar el MENDOZA por el nombre de la instancia de su SQL Server.Guardar
7. En la carpeta del proyecto se encuentra un archivo "APP.config", editarlo y buscar lo siguiente:
<connectionStrings>
        <add name="Prueba.Properties.Settings.PruebaConnectionString"
            connectionString="Data Source=MENDOZA;Initial Catalog=Prueba;Integrated Security=True"
            providerName="System.Data.SqlClient" />
    </connectionStrings>
    En Data Source, cambiar por el MENDOZA por el nombre de su instancia. Guardar.
8. Recompilar la solucion en Visual Studio y luego ejecutar el programa en Debug y 
realizar las pruebas necesarias.


