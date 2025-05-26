# Trabajo Práctico 3 – Buenas Prácticas en Desarrollo Back-End

## Alumna: Valentina Lorefice

https://github.com/valentinalorefice/TP3_backend

### 🎯 Objetivo del trabajo

El objetivo fue aplicar buenas prácticas de desarrollo back-end sobre una API existente, utilizando conceptos fundamentales como:

- Uso de DTOs para evitar exponer directamente las entidades del modelo.
- Configuración y uso de AutoMapper para mapear entidades ↔ DTOs.
- Implementación del patrón Repositorio para separar la lógica de acceso a datos.
- Inyección de dependencias y desacoplamiento de capas.
- Refactorización del controlador para utilizar servicios y mantener la responsabilidad única.

### 🧱 Cambios realizados

#### ✅ DTO (`Dto/ArticuloDto.cs`)
- Se creó una clase DTO con las propiedades necesarias para la comunicación con el cliente.
- Evita el uso directo del modelo `Articulo`.

#### ✅ AutoMapper (`MappingConfig.cs`)
- Configurado para mapear automáticamente entre `Articulo` y `ArticuloDto`.
- Registrado en `Program.cs` como singleton.

#### ✅ Repositorio
- Se creó una interfaz `IArticuloRepositorio` que define los métodos CRUD.
- Se creó una clase `ArticuloRepositorio` que implementa esa interfaz y simula persistencia en memoria.
- Inyectado en `Program.cs` como scoped service.

#### ✅ Refactorización del controlador
- `ArticulosController` fue modificado para:
  - Usar el repositorio en lugar de `ApplicationDbContext` directamente.
  - Mapear entre entidades y DTOs usando `IMapper`.
  - Mantener la lógica desacoplada y fácil de testear.

---

### 💡 Comentarios finales

- El proyecto sigue funcionando como una API REST, pero ahora con una arquitectura más limpia y escalable.
- Se aplicaron los principios de **Responsabilidad Única**, **Separación de capas**, y **Desacoplamiento**.
- Las clases nuevas cumplen los requerimientos del trabajo práctico y reflejan el uso de buenas prácticas modernas.


