var builder = WebApplication.CreateBuilder(args);

// Registro de servicios (DbContext, repositorios, servicios de negocio,
// MVC) se configura mañana.

var app = builder.Build();

// Pipeline de middlewares y mapeo de rutas se configura mañana.

app.Run();
