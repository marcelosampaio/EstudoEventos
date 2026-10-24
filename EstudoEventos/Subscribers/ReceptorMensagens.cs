using System;
using EstudoEventos.Events;

namespace EstudoEventos.Subscribers
{
    public class ReceptorMensagens
    {
        public void AoReceberMensagem(object sender, MensagemEventArgs e)
        {
            Console.WriteLine($"[Receptor] Mensagem capturada com sucesso!");
            Console.WriteLine($"-> Remetente: {sender?.GetType().Name}");
            Console.WriteLine($"-> Conteúdo recebido: {e.Conteudo}\n");
        }
    }
}