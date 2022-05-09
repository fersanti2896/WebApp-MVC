# Web App con ASP.NET MVC

Es un proyecto desarrollado en ASP.NET 6 con MVC, donde se hace un CRUD (Create-Read-Update-Delete) hacia una base de datos de Contáctos. 

Se detalla a continuación lo que abarca el proyecto:

1. __Definición de llaves hacia SQL.__
2. __Conexión a la BD.__
3. __Definición del modelo.__
4. __Definición de querys del modelo.__
5. __Definición del controlador.__ 
6. __Creación de las vistas.__
    6.1 __Listar.__
    6.2 __Crear.__
    6.3 __Editar.__
    6.4 __Eliminar.__
7. __Resultados__

### Definición de llaves hacia SQL

Con `appsettings.json` se definen la conexión hacia el motor de bases de datos, en este caso para SQL Server.

![appSettings](/images/appSettings.png)

### Conexión hacia la BD

Una vez definida la conexión hacia el moto de base de datos, con la clase `ConfigurationBuilder()` se define la ruta con el archivo `appsettings.json`.

![conexionDB](/images/conexionDB.png)

### Definición del modelo

Damos el mismo tipado y propiedades con una clase que tiene nuestra tabla Contáctos donde se encuentra nuestra base de datos en SQL Server. Misma que usará para hacer las consultas y posteriormente nuestro controlador. 

![mantenedorModel](/images/mantenedorModel.png)

### Definición de Querys del modelo 

Una vez creado nuestro modelo que mapeará a la tabla de Contáctos en nuestra base de datos, se definen las consultas propias de CRUD, cabe resaltar que estas consultas mapean hacia procedimientos almacenados (`StoredProcedure`) previamente definidos en nuestra base de datos. 

![mantedorQuerys](/images/mantenedorQuerys.png)

### Definición del controlador

Teniendo nuestro modelo y la clase que define las consultas hacia nuestra base de datos.

Se crea el controlador que hace las acciones entre el modelo y lo traspasa hacia la clase `View()` para que pueda ser mostrado.

![mantenedorController](/images/mantenedorController.png)

### Creación de vistas

#### Listar

Para la vista `Listar.cshtml` se define con una etiqueta de _Razor_ hacia la clase modelo que traerá las propiedades que se usarán para que puedan ser mostradas. 

![listContact](/images/listContact.png)

#### Crear

Para la vista `Guardar.cshtml` se define con una etiqueta de _Razor_ hacia la clase modelo que traerá las propiedades que se usará para crear un nuevo contacto. 

![createContact](/images/creatContact.png)


#### Editar

Para la vista `Editar.cshtml` se define con una etiqueta de _Razor_ hacia la clase modelo que traerá las propiedades que se usará para editar un contacto. 

![editContact](/images/editContact.png)

#### Eliminar

Para la vista `Eliminar.cshtml` se define con una etiqueta de _Razor_ hacia la clase modelo que traerá el id que se usará para eliminar un contacto. 

![deleteContact](/images/deleteContact.png)

### Resultados

Las vistas finales son:

Para el listado de contactos.

![listado](/images/image1.PNG)

Para la creación de un nuevo contacto.

![creacion](/images/image2.PNG)

Para actualizar un contacto existente. 

![actualizacion](/images/image3.PNG)

Par eliminar un contacto.  

![eliminacion](/images/image4.PNG)

Listado final

![listadoFinal](/images/image5.PNG)
