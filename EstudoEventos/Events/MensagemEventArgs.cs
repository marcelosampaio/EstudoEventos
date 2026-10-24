using System;

namespace EstudoEventos.Events
{
    // Carga útil (Payload) transmitida pelo evento
    public class MensagemEventArgs : EventArgs
    {
        public string Conteudo { get; }

        public MensagemEventArgs(string conteudo)
        {
            Conteudo = conteudo;
        }
    }
}