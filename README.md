# WpfTestRecorder

**Una solución de proyecto .NET 8.0** para grabar y reproducir tests de interfaz de usuario.

## Descripción

WpfTestRecorder es una aplicación .NET 8.0 que permite grabar y reproducir acciones de pruebas de interfaz de usuario. Aunque fue diseñada originalmente para WPF, la implementación actual es multiplataforma y funciona como una aplicación de consola interactiva.

## Estructura del Proyecto

La solución contiene los siguientes proyectos:

- **WpfTestRecorder.App** - Aplicación principal de consola
- **WpfTestRecorder.Core** - Biblioteca principal con la lógica de grabación/reproducción
- **WpfTestRecorder.Tests** - Proyecto de pruebas unitarias

## Requisitos

- .NET 8.0 SDK o superior

## Compilación

```bash
# Clonar el repositorio
git clone https://github.com/antonpolenyaka/WpfTestRecorder.git
cd WpfTestRecorder

# Restaurar dependencias y compilar
dotnet build

# Ejecutar pruebas
dotnet test

# Ejecutar la aplicación
dotnet run --project src/WpfTestRecorder.App
```

## Uso

La aplicación proporciona una interfaz de línea de comandos interactiva con los siguientes comandos:

- `record, r` - Iniciar grabación de acciones de prueba
- `stop, s` - Detener grabación
- `demo, d` - Ejecutar una grabación de demostración
- `list, l` - Listar acciones grabadas
- `clear, c` - Limpiar todas las acciones grabadas
- `save` - Guardar prueba en archivo
- `load` - Cargar prueba desde archivo
- `help, h, ?` - Mostrar ayuda
- `exit, q` - Salir de la aplicación

## Características

- ✅ Grabación de acciones de interfaz de usuario
- ✅ Soporte para múltiples tipos de acciones (click, doble click, teclas, texto)
- ✅ Guardado/carga de pruebas en formato JSON
- ✅ Interfaz de línea de comandos interactiva
- ✅ Multiplataforma (.NET 8.0)
- ✅ Pruebas unitarias completas

## Ejemplo de Uso

```bash
WPF Test Recorder> demo
Running demo test recording...
Demo recording completed!
Recorded 4 actions.

WPF Test Recorder> list

Recorded Actions (4):
--------------------------------------------------
  1. Click at (100, 200) on Button
  2. Type text: "Hello, World!"
  3. Key press: Enter
  4. Double-click at (300, 150) on ListItem
```

## Arquitectura

- **TestRecorder**: Clase principal para grabación y reproducción
- **TestAction**: Representa una acción de prueba individual
- **TestActionType**: Enumeración de tipos de acciones soportadas

## Contribución

Las contribuciones son bienvenidas. Por favor, asegúrate de que todas las pruebas pasen antes de enviar un pull request.

## Licencia

Ver archivo LICENSE para más detalles.
