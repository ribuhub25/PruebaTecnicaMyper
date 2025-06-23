# PruebaTecnicaMyper
# Proyecto de Mantenimiento de Trabajadores
Este proyecto implementa una arquitectura en capas utilizando:

- **UI**: Interfaz de usuario con Razor Pages y Bootstrap.
- **BLL** (Business Logic Layer): Contiene la lógica de negocio.
- **DAL** (Data Access Layer): Encapsula el acceso a datos y repositorios.
- **Domain**: Define las entidades y modelos.

## Scaffolding de la base de datos

Para generar el contexto y las entidades desde la base de datos, se utilizó el siguiente comando:

```powershell
Scaffold-DbContext "Server=LAPTOP-34FHF1PD;Database=TrabajadoresPrueba;User ID=sa;Password=mardecopas;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -ContextDir DataContext -Context MyperContext
