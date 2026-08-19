namespace secure_password.Services;

public interface IPasswordValidator
{
    bool Validate(string? senha, out List<string> erros);
}

public sealed class PasswordValidator : IPasswordValidator
{
    public bool Validate(string? senha, out List<string> erros)
    {
        erros = [];

        if (string.IsNullOrEmpty(senha))
        {
            erros.Add("A senha não pode ser nula ou vazia");
            return false;
        }

        if (senha.Length < 8)
            erros.Add("A senha precisa ter pelo menos 8 caracteres");

        if (!senha.Any(char.IsUpper))
            erros.Add("A senha precisa ter uma letra maiúscula");

        if (!senha.Any(char.IsLower))
            erros.Add("A senha precisa ter uma letra minúscula");

        if (!senha.Any(char.IsDigit))
            erros.Add("A senha precisa ter um número");

        if (!senha.Any(c => char.IsSymbol(c) || char.IsPunctuation(c)))
            erros.Add("A senha precisa ter um caractere especial");

        return erros.Count == 0;
    }
}
