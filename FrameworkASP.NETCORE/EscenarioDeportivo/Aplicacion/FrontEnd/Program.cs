using Persistencia;
//Importante tener aquí el builder.Services.AddDbContext<>
//Para poder Listar las entidades en la página web

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Crear un contexto de datos, (Conectar con el db Context)
builder.Services.AddDbContext<Persistencia.AppContext>();

//Inyección de dependencias por cada interfaz y la clase que implementa
builder.Services.AddScoped<IRArbitro,RArbitro>();
builder.Services.AddScoped<IRColegioInstruccion,RColegioInstruccion>();
builder.Services.AddScoped<IRDeportista,RDeportista>();
builder.Services.AddScoped<IREntrenador,REntrenador>();
builder.Services.AddScoped<IREquipo,REquipo>();
builder.Services.AddScoped<IREscenario,REscenario>();
builder.Services.AddScoped<IRMunicipio,RMunicipio>();
builder.Services.AddScoped<IRPatrocinador,RPatrocinador>();
builder.Services.AddScoped<IRTorneo,RTorneo>();
builder.Services.AddScoped<IRUnidadDeportiva,RUnidadDeportiva>();
builder.Services.AddScoped<IRTorneoEquipo,RTorneoEquipo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
