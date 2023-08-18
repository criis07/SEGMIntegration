# lafise.test.Api.Solution

![badge](resources/LAFISE-REST_API-blue.png)

Plantilla global de solución de proyecto WebApi con arquitectura limpia versión Lite (Sin dependencias de bases de datos ni manejo de ellas directamente).

## Requerimientos

- `dotnet-cli`
- .net6 SDK (6.0.30 o superior)
- Visual Studio 2022 o Visual Studio Code 1.64 o superior. (Si usa vscode, instalar las extensiones recomendadas)
- Commitizen-cli

> Recuerde siempre ejecutar `dotnet new update`

# Preparación

Como parte del proceso de calidad de código, en esta plantilla tenemos preparado el uso de git hooks para ejecutar verificaciones al momento de hacer commit. Para ello hacemos uso de una herramienta python llamada `commitizen-cli`, si esta herramienta no está instalada, no se podrá hacer commit.

Para instalar esta herramienta debe tener instalado y configurado `python 3.9` o superior, configurar el feed privado del Azure Devops, e instalar la herramienta.

```ps
pip install --user commitizen
```

## Instalación

Para hacer uso de la plantilla se debe escribir su **Short Name**. Recuerde que debe estar en la carpeta padre de la cual desea crear su proyecto (Si deseo crear el proyecto `MoneyApi` dentro de la carpeta `home/repos`, debo ejecutar el comando dentro de la carpeta `home/repos`)

```ps
> dotnet new ca-webapi-lite-sln -n <NombreProyecto> -o .\<NombreProyecto>\
```

Si está utilizando Visual Studio 2022, recuerde siempre marcar la opción *Colocar proyecto y solución en la misma carpeta*

Posteriormente debe ejecutar dentro de la carpeta de la solución, el comando `git init`.


## Clean Architecture

**Clean architecture** es un conjunto de principios cuya finalidad principal es ocultar los detalles de la implementación a la lógica de dominio de la aplicación, con el fin de que esta lógica se mantenga aislada e independiente de la implementación, haciéndola más mantenible y escalable en el tiempo.

![Diagrama de Clean Architecture](https://ni-cfl-dvps-1a.ni.lafise.corp/BLNI-Gerencia%20Sistemas%20Electronicos/9d3ede1b-e409-4f09-902b-df4a80d9868b/_apis/git/repositories/b77d0a99-7535-401f-a82a-1a010fa6b025/Items?path=%2Fresources%2Fcleanarcht.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=master&download=false&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1)

### Regla de dependencia

La principal característica de **Clean Architecture** frente a otras arquitecturas es la **regla de dependencia**, divide la aplicación en responsabilidades, representadas en forma de capas, obteniendo como resultado la existencia de capas exteriores e interiores.

- Las capas exteriores representan los detalles de implementación (tipo de aplicación, medio de despliegue, interfaces de uso, etc).
- Las capas interiores representan el dominio de la aplicación, incluyendo la lógica de la aplicación y la lógica de negocio empresarial.

La regla de dependencia define que las capas interiores **no** deben conocer nada de las capas exteriores; sin embargo, las capas exteriores **sí** pueden conocer acerca de las capas interiores.

El uso de estas arquitecturas nos dan sistemas que son:

- **Independientes de frameworks**: la arquitectura no depende de la existencia de librerías o características de algún software, permitiendo extrapolar los límites del sistema fuera de las limitaciones de un determinado framework.
- **Testeables**: las reglas de negocio pueden ser probadas sin la UI, base de datos, servidor web o cualquier otro elemento externo.
- **Independientes de UI**: la UI (presentación) puede ser cambiada fácilmente, sin perjudicar el resto del sistema. Una UI web puede ser remplazada por una UI en consola, sin cambiar las reglas de negocio.
- **Independientes de bases de datos**: las reglas de negocio no estan vinculadas a un determinado motor de base de datos. Los motores de `ORM` y `SQL as REST API` facilitan estas implementaciones.
- **Independientes de agencias externas**: las reglas de negocio no conocen nada del mundo exterior.

### Principios SOLID

Los principios SOLID son 5 principios básicos de la programación orientada a objetos, con el fin de crear sistemas fáciles de mantener y ampliar con el tiempo. Estos principios son requeridos para la implementación de clean Architecture.

|Inicial|Acrónimo|Concepto|
|-------|--------|--------|
|**S**|SRP|**Principio de responsabilidad única**: cada objeto debe tener una sola responsabilidad|
|**O**|OCP|**Principio de abierto/cerrado**: las entidades de software deben estar abiertas para su extensión y cerradas para su modificación|
|**L**|LSP|**Principio de sustitución de Liskov**: los objetos de un programa deberían ser reemplazables por instancias de sus subtipos sin alterar el correcto funcionamiento del programa|
|**I**|ISP|**Principio de segregación de la interfaz**: se debe preferir tener muchas interfaces específicas para cada cliente que una sola interfaz de uso general|
|**D**|DIP|**Principio de inversión de la dependencia**: se debe depender de abstracciones, no de implementaciones, como se hace por ejemplo, en la inyección de dependencias.|

###Inyección de dependencias

La inyección de dependencias es un patrón de arquitectura de programación orientada a objetos determinado para cuplir con el **principio de inversión de la dependencia**, a ser implementado en la *clean architecture*, ya que permite definir las dependencias en la capa de lógica de negocio, e implementar estas dependencias en otras capas mas exteriores, por ejemplo, capa de infraestructura.

Un ejemplo sencillo de inyección de de dependencias sería definir, en la capa de aplicación (encargada de la lógica del negocio) un servicio de consultas a un API externo. Al ser un servicio de consumo de interfaces externas, es necesario relevar su implementación a una capa superior, la capa de infraestructura en este caso. Entonces tenemos lo siguiente:

**`ILibraryService.cs`**

```csharp
namespace Clean.Architecture.Application.Common.Interfaces
{
    public interface ILibraryService
    {
        /// <summary>
        /// Obtiene todas las librerías existentes en un país desde 
        /// el API externo de librerías dado el país
        /// </summary>
        /// <param name="country">País a buscar</param>
        /// <returns>Listado con las librerías. La lista puede ser vacía</returns>
        Task <List<Library>> GetLibrariesByCountry(Country country);
    }
}
```
En este bloque se define una interfaz con un método documentado del cual se hará uso en la lógica del negocio, mas la implementación de este método no corresponde a la capa de aplicación.

**`LibraryService.cs`**

```csharp
namespace Clean.Architecture.Infrastructure.Services.Library
{
    public class LibraryService : ILibraryService
    {
        public async Task <List<Library>> GetLibrariesByCountry(Country country)
        {
            var libraryList = new List<Library>();
            // Implementación del método
            return libraryList;
        }
    }
}
```
En este bloque se lleva a cabo la implementación del método que se usará para consultar la información a un API externa.

Lo único que faltaría sería definir la relación entre la abstracción y la implementación, lo cual se hace de la siguiente manera:

**`DependencyInjection.cs`**

```csharp
using Clean.Architecture.Application.Common.Interfaces;
using Clean.Architecture.Infrastructure.Services.Library;

namespace Clean.Architecture.Infrastructure
{
    public static class DependencyInjection 
    {
        
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
        IConfiguration configuration)
        {
            services.AddHttpClient<ILibraryService, LibraryService>();

            return services;
        }
    }
}
```
De esta manera se define la inyección para poder depender de la abstracción, pero al momento de ejecutar el código se tomará en cuenta la implementación.

###Capas elementales

Esta plantilla de Clean Architecture cuenta con una definición por 4 capas, perfectamente ampliables a las necesidades de diversos proyectos.

####Dominio

Es la capa que controla todo lo referente a las entidades, modelos de bases de datos, tipos de datos, enumeraciones, contratos de API de consumo interno, modelos de excepciones, modelos de respuestas, extensiones, etc.

Debe ser la capa más profunda de toda la arquitectura y no debe tener dependencia de ninguna otra capa.

Se puede concatenar el dominio de cualquier proyecto con el dominio de otro proyecto que cumpla las características similares.

####Aplicación

Es la capa que controla todo lo referente a la lógica del negocio, las clases y métodos encargados de llevar a cabo cambios en los datos, transacciones, cálculos, validaciones de negocio, validaciones de integridad, etc. 

La capa de aplicación depende únicamente de la capa de dominio.

El manejo de las acciones en la capa de aplicación se hace mediante el patrón de CQRS *Command Query Responsibility Segregation*, usando el paquete Nuget [MediatR](https://www.nuget.org/packages/MediatR/). Esto define que cada acción (`Request`) debe tener una rutina de código independiente, sea esa una query (*consulta de datos*) o un command (*transacción de datos*).

Las rutinas de código están compuestas por un `Query` o `Command`, que define los datos de entrada, un `Validator` que ejecute validaciones de correctitud de datos (formato, longitud, etc), no relacionadas con negocio (ver [FluentValidation](https://docs.fluentvalidation.net/en/latest/)), y finalmente y `Handler`, que se encarga de llevar a cabo toda la lógica del negocio interna del Request, tales como validaciones de negocio, subconsultas a servicios externos, transacciones de datos, etc.

En esta capa también deben de definirse todas las dependencias abstractas referentes a consumo de servicios externos (APIs, servicios, bases de datos) que se utilizarán en los distintos handlers, las cuales, deberán ser implementadas desde la capa de Infraestructura.

####Infraestructura

Es la capa que maneja las implementaciones de consumo y transaccionalidad de servicios externos al sistema, ya sea bases de datos, servicios, APIs, etc. Aquí es donde deben implementarse mediante inyección de dependencia todas las dependencias abstractas definidas en Aplicación.

La capa de infraestructura depende de las capas de dominio (consumo de entidades, datos, enumeraciones) y de aplicación (definición de abstracciones).

####Capas de Presentación

Son todas las capas relacionadas con el programa externo que compone al sistema, es decir, la interfaz final. Esta capa puede ser cualquier tipo de aplicación de .NET Core, ya sea aplicación de consola, sitio web MVC, Razor Pages, REST API, Amazon SQS, etc. Puede existir más de una capa de presentación para una capa de aplicación.

Las capas de presentación deben depender únicamente de la capa de Aplicación, y se comunicaran a esta mediante [MediatR](https://www.nuget.org/packages/MediatR/), a través de `IMediator.Send();`. En el siguiente ejemplo se puede ver el llamado a un query desde una capa de presentación de REST API.

```csharp
/// <summary>
/// Get List Departments by BANK_ID
/// </summary>
/// <remarks>&lt;p&gt;Get the list of departments for a specified BANK_ID&lt;/p&gt;</remarks>
/// <param name="BANK_ID">The bank id</param>
/// <response code="200">Success</response>
/// <response code="400">Error</response>
[HttpGet]
[Route("//obl/v1/banks/{BANK_ID}/sample/departments")]
[SwaggerOperation("Projectv1GetDepartmentByCountryAsync")]
public virtual async Task<IActionResult> Projectv1GetDepartmentByCountryAsync
([FromRoute][Required] CountryEnum BANK_ID)
{
    var response = BANK_ID switch
    {
        CountryEnum.BLNI => await Mediator.Send(new GetDepartamentsBLNIQuery(BANK_ID)),
        CountryEnum.BLCR => throw new NotImplementedException(),
        CountryEnum.BLHN => throw new NotImplementedException(),
        CountryEnum.BLPA => throw new NotImplementedException(),
        CountryEnum.BLRD => throw new NotImplementedException(),
        _ => throw new NotImplementedException(),
    };

    return Ok(response);
}
```