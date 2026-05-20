# API de Cadastro de Pets

## Tema

Esta API permite gerenciar pets.

## Tecnologias utilizadas

- C#
- ASP.NET Core Minimal API
- Entity Framework Core
- SQLite

## Como executar

```bash
dotnet run
```

## Endpoints

| Método | Rota | Descrição |
| --- | --- | --- |
| GET | `/` | Mensagem inicial |
| GET | `/status` | Status da API |
| GET | `/pets` | Lista todos os pets |
| GET | `/pets/{id}` | Busca um pet por ID |
| POST | `/pets` | Cadastra um pet |
| PUT | `/pets/{id}` | Atualiza um pet |
| DELETE | `/pets/{id}` | Remove um pet |
| GET | `/pets/vivo` | Lista pets vivos |

## Exemplo de JSON

```json
{
  "id": 3,
  "especie": "Coelho",
  "peso": 2.55,
  "vivo": false,
  "dataCadastro": "2026-05-20T13:12:48.8612899-03:00"
}
```
### Arquivo com as requisições HTTP (Ferramenta BRUNO)
- em ZIP: 
- em YML: 

## Vídeo explicativo

- Link do vídeo: https://drive.google.com/file/d/134P1vuXkCFVq_W9j0L-UdCM65Qagj3kQ/view?usp=sharing
