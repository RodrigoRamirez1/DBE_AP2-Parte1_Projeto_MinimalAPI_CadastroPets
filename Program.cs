using System.IO.Compression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}


app.MapGet("/", () => "API de Cadastro de Pets - Minimal API com .NET");


app.MapGet("/status", () => new
{
    status = "online",
    mensagem = "API funcionando",
    dataHora = "2026-05-13T19:30:00"
});


app.MapGet("/pets", async (AppDbContext db) =>
{
    var pets = await db.Pets.ToListAsync();
    return Results.Ok(pets);
});

app.MapGet("/pets/{id}", async (int id, AppDbContext db) =>
{
    var pet = await db.Pets.FindAsync(id);
    if(pet == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(pet);
    
});

app.MapPost("/pets", async (Pet petRequest, AppDbContext db) =>
{
    db.Pets.Add(petRequest);
    await db.SaveChangesAsync();
    return Results.Created($"/pets/, {petRequest.Id}", petRequest);
});

app.MapPut("/pets/{id}", async (int id, Pet petAtualizado, AppDbContext db) =>
{
    var pet = await db.Pets.FindAsync(id);
    if(pet == null)
    {
        return Results.NotFound("Pet não cadastrado!");
    }

    pet.Especie = petAtualizado.Especie;
    pet.Peso = petAtualizado.Peso;
    pet.Vivo = petAtualizado.Vivo;
    pet.DataCadastro = DateTime.Now;

    await db.SaveChangesAsync();
    return Results.Ok(pet);
});

app.MapDelete("/pets/{id}", async (int id, AppDbContext db) =>
{
    var pet = await db.Pets.FindAsync(id);
    if(pet == null)
    {
        return Results.NotFound();
    }

    db.Pets.Remove(pet);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

//Desafio Extra

app.MapGet("/pets/vivo", async (AppDbContext db) =>
{
    var petsVivos = await db.Pets.Where(p => p.Vivo == true).ToListAsync();

    if (petsVivos.Count == 0)
    {
       return Results.NotFound("Não existem pets vivos cadastrados."); 
    }

    return Results.Ok(petsVivos);

});
app.Run();

