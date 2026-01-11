using System.ComponentModel;

namespace Sistema_Bancário_Simples
{
    public enum UserEnum
    {
        [Description("Usuário criado com sucesso.")]
        UserCreated,

        [Description("Usuário logou com sucesso")]
        LoginSuccess,

        [Description("Email ou senha incorretos.")]
        LoginFailed,

        [Description("Já existe um usuário com esse email.")]
        UserExists,

        [Description("Os seguintes campos estão vazios: ")]
        EmptyFields,

        [Description("Email inválido.")]
        InvalidEmail,

        [Description("A senha deve ter pelo menos 6 caracteres.")]
        WeakPassword


    }
}
