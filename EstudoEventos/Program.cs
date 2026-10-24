using System;
using EstudoEventos.Publishers;
using EstudoEventos.Subscribers;

namespace EstudoEventos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Iniciando Aplicação: Padrão Publisher/Subscriber (Eventos) ===\n");

            // Instanciação dos componentes independentes
            var emissor = new EmissorMensagens();
            var receptor = new ReceptorMensagens();

            // 1. Acoplamento dinâmico via operador de subscrição (+=)
            // Equivalente a adicionar um Observer ou registrar em um NotificationCenter
            emissor.MensagemEnviada += receptor.AoReceberMensagem;

            // 2. Disparando o evento pela primeira vez
            emissor.EnviarMensagem("Olá, arquitetura Pub/Sub em memória no .NET!");

            // 3. Dessubscrição para prevenção de Memory Leaks (-=)
            // No iOS, se você mantém uma strong reference em closures ou delegates, gera ciclo de retenção.
            // No .NET, o publicador mantém uma referência forte para o assinante enquanto durar a subscrição.
            emissor.MensagemEnviada -= receptor.AoReceberMensagem;

            Console.WriteLine("[Sistema] Assinatura removida. Tentando enviar nova mensagem...");
            
            // Esta mensagem não será capturada pelo receptor, pois ele foi dessubscrito
            emissor.EnviarMensagem("Esta mensagem não terá receptores ouvindo.");

            Console.WriteLine("\n=== Fim da Execução da Aula 02 ===");
        }
    }
}