using System;
using EstudoEventos.Events;

namespace EstudoEventos.Publishers
{
    public class EmissorMensagens
    {
        // Declaração do Delegate padrão para eventos do .NET (EventHandler com tipo genérico)
        public event EventHandler<MensagemEventArgs> MensagemEnviada;

        public void EnviarMensagem(string conteudo)
        {
            Console.WriteLine($"[Emissor] Processando e enviando mensagem: '{conteudo}'");
            
            // Disparo thread-safe utilizando o operador null-conditional (?.Invoke)
            // O 'this' representa o remetente (sender)
            OnMensagemEnviada(conteudo);
        }

        protected virtual void OnMensagemEnviada(string conteudo)
        {
            MensagemEnviada?.Invoke(this, new MensagemEventArgs(conteudo));
        }
    }
}