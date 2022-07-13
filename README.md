# Trabajo-POO
Integrantes:
Bruno, Tadeo
Martínez, Máximo
Pisana, Gastón
Turró, Francisco


El sistema esta construido con el patrón de diseño Modelo-Vista-Controladora (MVC), que separa al sistema en tres partes:
Modelo, que maneja datos y lógica.
Vista, que maneja la presentación del programa.
Controladora, que actúa como intermediario de la vista y el modelo, gestionando el flujo de información entre ellos.

También se usa el patrón de diseño Singleton, permitiendo que una clase tenga una sola instancia, usado en este sistema ya que se busca que la instancia de ciertos datos esté disponible para toda la aplicación, como es la información de los usuarios, los formularios o la propia base de datos.

El sistema esta conectado a una base de datos, y consiste en una serie de formularios, el primero de ellos pidiendo que se ingrese la información de un usuario valido (que este cargado en la base de datos). Cada usuario tiene un perfil, y cada perfil tiene uno o varios formularios, los cuales tienen permisos. Al ingresar un usuario se accede al formulario principal, que dependiendo de los formularios a los que tiene acceso el usuario actual carga distintos botones, los que permiten acceder a otros formularios. Así se restringe el acceso a formularios para usuarios. El resto de los formularios del sistema permiten ingresar usuarios y perfiles nuevos a la base de datos.
Cabe destacar que en los mismos formularios hay restricciones en la funcionalidad para distintos usuarios. Para realizar la separación entre los usuarios que pueden eliminar usuarios y elegir el perfil dado a un nuevo usuario creado (no tiene sentido que un empleado pueda crear un usuario de tipo gerente) originalmente se checkeaba que el usuario actual tenga un perfil de nombre “Gerente”. Si no tenía este nombre de perfil entonces se escondían los botones y comboboxes correspondientes. 
Se terminó cambiando esto cuando se agregó la opción de crear perfiles, ya que si quiere crear un perfil que tenga las mismas capacidades de un perfil gerente, pero un nombre distinto, no va a funcionar. Para esto se usan los permisos. El perfil gerente tiene acceso a un formulario con permisos para modificar y eliminar usuarios, por lo que al crearse un nuevo perfil con capacidades de admin, se agrega el formulario correspondiente a una lista, que después se agrega al nuevo perfil creado. Se usa un foreach en los distintos formularios a los que tiene acceso el usuario para iterar por los distintos permisos hasta que se encuentra el indicado.

Al iniciar el sistema se carga una base de datos con 2 perfiles, Gerente y Empleado.
Gerente tiene acceso a los formularios “GestionarClientes” y “CrearPerfil”, mientras que Empleado solo puede acceder a “GestionarClientes” (Los nombres son tentativos y no son definitivos, el sistema está en desarrollo). El formulario GestionarClientes solamente permite agregar y modificar usuarios a la base de datos, mientras que CrearPerfil permite agregar, modificar y eliminar clientes, además de crear nuevos perfiles. 
