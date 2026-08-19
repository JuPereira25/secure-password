# Secure Password

API simples em ASP.NET Core para verificar se uma senha é segura.

## Regras da senha

A senha deve ter:

- Pelo menos 8 caracteres;
- Uma letra maiúscula;
- Uma letra minúscula;
- Um número;
- Um caractere especial.

## Como executar

É necessário ter o .NET 10 instalado.

```bash
cd secure-password
dotnet run --launch-profile http
```

A API ficará disponível em:

```text
http://localhost:5118
```

## Como testar

Envie uma requisição `POST` para `/validate-password`:

```http
POST http://localhost:5118/validate-password
Content-Type: application/json

{
  "password": "Senha@123"
}
```

Uma senha válida retorna `204 No Content`.

Uma senha inválida retorna `400 Bad Request` com a lista de regras que não foram atendidas:

```json
{
  "errors": [
    "A senha precisa ter pelo menos 8 caracteres",
    "A senha precisa ter uma letra maiúscula"
  ]
}
```

Também é possível executar a requisição pronta no arquivo `secure-password/secure-password.http`.

## Estrutura

```text
secure-password/
├── Controller/  # Endpoint da API
├── Dtos/        # Dados recebidos na requisição
├── Service/     # Regras de validação da senha
└── Program.cs   # Configuração da aplicação
```
