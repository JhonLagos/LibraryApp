# LibraryApp

Proyecto 1:
Se requiere un API RESTFul en .NET Core o NET 5 que permita:
Registrar los datos de un libro: Titulo, Año, Genero, Número de páginas, Editorial, Autor.
Registrar los datos de los autores: Nombre completo, Fecha de nacimiento, Ciudad de procedencia, Correo electrónico.
Registrar los datos de las editoriales: Nombre, Dirección de Correspondencia, Teléfono, Correo electrónico, Máximo de libros registrados.

Reglas de negocio:
Todos los datos marcados con asterisco son obligatorios.
Se debe garantizar la integridad de la información.
Las editoriales pueden tener un máximo de libros registrados, en caso de no existir límite, se indica -1.
Si al intentar registrar un libro se supera el máximo permitido, debe generarse una excepción y responder con el mensaje: “No es posible registrar el libro, se alcanzó el máximo permitido.”.
Si al intentar registrar un libro y no existe:
o Autor: Responder con el mensaje: “El autor no está registrado”.
o Editorial: Responder con el mensaje: “La editorial no está registrada”.


Proyecto 2:
Se requiere un frontend en Angular para buscar los libros registrados en el sistema.
El sistema debe permitir buscar por palabras clave como el autor, titulo, año.
Aspectos Técnicos:
o Usar Angular 6 o mayor versión.
o Usar componentes, servicios, observadores, bootstrap (o cualquier librería UI).
o Una buena organización y estructura del proyecto serán tomadas en cuenta.
o Una buena maquetación de templates serán tomadas en cuenta.
