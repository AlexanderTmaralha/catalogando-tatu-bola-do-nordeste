using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CadastroAnimal
{
    class Program
    {
        static string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "fichas_cadastrais.txt");
        static List<FichaCadastral> fichasCadastrais = new List<FichaCadastral>();

        static void Main(string[] args)
        {
            fichasCadastrais = LoadData();

            while (true)
            {
                Console.WriteLine("1. Adicionar nova ficha");
                Console.WriteLine("2. Exibir ficha");
                Console.WriteLine("3. Salvar e sair");
                Console.Write("Escolha uma opção: ");
                int opcao = ReadInt("");

                if (opcao == 1)
                {
                    AdicionarFicha();
                }
                else if (opcao == 2)
                {
                    ExibirFicha();
                }
                else if (opcao == 3)
                {
                    SaveData();
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida! Tente novamente.");
                }
            }
        }

        static void AdicionarFicha()
        {
            var ficha = new FichaCadastral
            {
                IdFicha = ReadInt("Id da Ficha:"),
                IdentificacaoAnimal = ReadString("Identificação do Animal:"),
                LocalCaptura = ReadString("Local de Captura:"),
                Peso = ReadDouble("Peso:"),
                NumeroMicrochip = ReadString("Número do Microchip:"),
                DataCaptura = ReadDateTime("Data de Captura (dd/MM/yyyy):"),
                HorarioCaptura = ReadTimeSpan("Horário de Captura (HH:mm):"),
                EquipeResponsavel = ReadString("Equipe Responsável:"),
                Instituicao = ReadString("Instituição:"),
                ContatoResponsavel = ReadString("Contato do Responsável:"),
                ComprimentoTotal = ReadNullableDouble("Comprimento Total:"),
                ComprimentoOrelha = ReadNullableDouble("Comprimento da Orelha:"),
                NumeroCintas = ReadNullableInt("Número de Cintas:"),
                ComprimentoCabeca = ReadNullableDouble("Comprimento da Cabeça:"),
                ComprimentoCauda = ReadNullableDouble("Comprimento da Cauda:"),
                LarguraCabeca = ReadNullableDouble("Largura da Cabeça:"),
                LarguraCauda = ReadNullableDouble("Largura da Cauda:"),
                PadraoEscudoCefalico = ReadString("Padrão do Escudo Cefálico:"),
                ComprimentoEscudoCefalico = ReadNullableDouble("Comprimento do Escudo Cefálico:"),
                SemicircunferenciaEscudoEscapular = ReadNullableDouble("Semicircunferência do Escudo Escapular:"),
                ComprimentoEscudoEscapular = ReadNullableDouble("Comprimento do Escudo Escapular:"),
                LarguraEscudoCefalico = ReadNullableDouble("Largura do Escudo Cefálico:"),
                ComprimentoEscudoPelvico = ReadNullableDouble("Comprimento do Escudo Pélvico:"),
                LarguraInterOrbital = ReadNullableDouble("Largura Inter-Orbital:"),
                SemicircunferenciaEscudoPelvico = ReadNullableDouble("Semicircunferência do Escudo Pélvico:"),
                LarguraInterLacrimal = ReadNullableDouble("Largura Inter-Lacrimal:"),
                LarguraNaSegundaCinta = ReadNullableDouble("Largura na Segunda Cinta:"),
                ComprimentoMaoSemUnha = ReadNullableDouble("Comprimento da Mão sem Unha:"),
                ComprimentoUnhaDaMao = ReadNullableDouble("Comprimento da Unha da Mão:"),
                ComprimentoPeSemUnha = ReadNullableDouble("Comprimento do Pé sem Unha:"),
                ComprimentoUnhaDoPe = ReadNullableDouble("Comprimento da Unha do Pé:"),
                ComprimentoPenis = ReadNullableDouble("Comprimento do Pênis:"),
                LarguraBasePenis = ReadNullableDouble("Largura da Base do Pênis:"),
                ComprimentoClitoris = ReadNullableDouble("Comprimento do Clitóris:")
            };

            fichasCadastrais.Add(ficha);
        }

        static void ExibirFicha()
        {
            int id = ReadInt("Informe o Id da ficha a ser exibida:");
            var fichaCadastral = fichasCadastrais.Find(f => f.IdFicha == id);

            if (fichaCadastral != null)
            {
                Console.WriteLine("Id da Ficha: {0}", fichaCadastral.IdFicha);
                Console.WriteLine("Identificação do Animal: {0}", fichaCadastral.IdentificacaoAnimal);
                Console.WriteLine("Local de Captura: {0}", fichaCadastral.LocalCaptura);
                Console.WriteLine("Peso: {0}", fichaCadastral.Peso);
                Console.WriteLine("Número do Microchip: {0}", fichaCadastral.NumeroMicrochip);
                Console.WriteLine("Data de Captura: {0}", fichaCadastral.DataCaptura.ToString("dd/MM/yyyy"));
                Console.WriteLine("Horário de Captura: {0}", fichaCadastral.HorarioCaptura.ToString(@"hh\:mm"));
                Console.WriteLine("Equipe Responsável: {0}", fichaCadastral.EquipeResponsavel);
                Console.WriteLine("Instituição: {0}", fichaCadastral.Instituicao);
                Console.WriteLine("Contato do Responsável: {0}", fichaCadastral.ContatoResponsavel);
                Console.WriteLine("Comprimento Total: {0}", fichaCadastral.ComprimentoTotal);
                Console.WriteLine("Comprimento da Orelha: {0}", fichaCadastral.ComprimentoOrelha);
                Console.WriteLine("Número de Cintas: {0}", fichaCadastral.NumeroCintas);
                Console.WriteLine("Comprimento da Cabeça: {0}", fichaCadastral.ComprimentoCabeca);
                Console.WriteLine("Comprimento da Cauda: {0}", fichaCadastral.ComprimentoCauda);
                Console.WriteLine("Largura da Cabeça: {0}", fichaCadastral.LarguraCabeca);
                Console.WriteLine("Largura da Cauda: {0}", fichaCadastral.LarguraCauda);
                Console.WriteLine("Padrão do Escudo Cefálico: {0}", fichaCadastral.PadraoEscudoCefalico);
                Console.WriteLine("Comprimento do Escudo Cefálico: {0}", fichaCadastral.ComprimentoEscudoCefalico);
                Console.WriteLine("Semicircunferência do Escudo Escapular: {0}", fichaCadastral.SemicircunferenciaEscudoEscapular);
                Console.WriteLine("Comprimento do Escudo Escapular: {0}", fichaCadastral.ComprimentoEscudoEscapular);
                Console.WriteLine("Largura do Escudo Cefálico: {0}", fichaCadastral.LarguraEscudoCefalico);
                Console.WriteLine("Comprimento do Escudo Pélvico: {0}", fichaCadastral.ComprimentoEscudoPelvico);
                Console.WriteLine("Largura Inter-Orbital: {0}", fichaCadastral.LarguraInterOrbital);
                Console.WriteLine("Semicircunferência do Escudo Pélvico: {0}", fichaCadastral.SemicircunferenciaEscudoPelvico);
                Console.WriteLine("Largura Inter-Lacrimal: {0}", fichaCadastral.LarguraInterLacrimal);
                Console.WriteLine("Largura na Segunda Cinta: {0}", fichaCadastral.LarguraNaSegundaCinta);
                Console.WriteLine("Comprimento da Mão sem Unha: {0}", fichaCadastral.ComprimentoMaoSemUnha);
                Console.WriteLine("Comprimento da Unha da Mão: {0}",

 fichaCadastral.ComprimentoUnhaDaMao);
                Console.WriteLine("Comprimento do Pé sem Unha: {0}", fichaCadastral.ComprimentoPeSemUnha);
                Console.WriteLine("Comprimento da Unha do Pé: {0}", fichaCadastral.ComprimentoUnhaDoPe);
                Console.WriteLine("Comprimento do Pênis: {0}", fichaCadastral.ComprimentoPenis);
                Console.WriteLine("Largura da Base do Pênis: {0}", fichaCadastral.LarguraBasePenis);
                Console.WriteLine("Comprimento do Clitóris: {0}", fichaCadastral.ComprimentoClitoris);
            }
            else
            {
                Console.WriteLine("Ficha não encontrada.");
            }
        }

        static void SaveData()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var ficha in fichasCadastrais)
                {
                    writer.WriteLine(ficha.ToString());
                }
            }

            Console.WriteLine("Fichas cadastrais salvas com sucesso no arquivo: {0}", filePath);
        }

        static List<FichaCadastral> LoadData()
        {
            var fichas = new List<FichaCadastral>();

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        var ficha = FichaCadastral.FromString(line);
                        if (ficha != null)
                        {
                            fichas.Add(ficha);
                        }
                    }
                }
            }

            Console.WriteLine("Fichas cadastrais carregadas com sucesso do arquivo: {0}", filePath);
            return fichas;
        }

        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message + " ");
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Valor inválido! Digite um número inteiro.");
                }
            }
        }

        static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message + " ");
                if (double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Valor inválido! Digite um número decimal.");
                }
            }
        }

        static DateTime ReadDateTime(string message)
        {
            while (true)
            {
                Console.Write(message + " ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Formato inválido! Digite no formato dd/MM/yyyy.");
                }
            }
        }

        static TimeSpan ReadTimeSpan(string message)
        {
            while (true)
            {
                Console.Write(message + " ");
                if (TimeSpan.TryParseExact(Console.ReadLine(), @"hh\:mm", CultureInfo.InvariantCulture, out TimeSpan result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Formato inválido! Digite no formato HH:mm.");
                }
            }
        }

        static string ReadString(string message)
        {
            Console.Write(message + " ");
            return Console.ReadLine();
        }

        static double? ReadNullableDouble(string message)
        {
            while (true)
            {
                Console.Write(message + " (deixe em branco para nulo): ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    return null;
                }
                else if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Valor inválido! Digite um número decimal válido ou deixe em branco.");
                }
            }
        }

        static int? ReadNullableInt(string message)
        {
            while (true)
            {
                Console.Write(message + " (deixe em branco para nulo): ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    return null;
                }
                else if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Valor inválido! Digite um número inteiro válido ou deixe em branco.");
                }
            }
        }
    }

    class FichaCadastral
    {
        public int IdFicha { get; set; }
        public string IdentificacaoAnimal { get; set; }
        public string LocalCaptura { get; set; }
        public double Peso { get; set; }
        public string NumeroMicrochip { get; set; }
        public DateTime DataCaptura { get; set; }
        public TimeSpan HorarioCaptura { get; set; }
        public string EquipeResponsavel { get; set; }
        public string Instituicao { get; set; }
        public string ContatoResponsavel { get; set; }
        public double? ComprimentoTotal { get; set; }
        public double? ComprimentoOrelha { get; set; }
        public int? NumeroCintas { get; set; }
        public double? ComprimentoCabeca { get; set; }
        public double? ComprimentoCauda { get; set; }
        public double? LarguraCabeca { get; set; }
        public double? LarguraCauda { get; set; }
        public string PadraoEscudoCefalico { get; set; }
        public double? ComprimentoEscudoCefalico { get; set; }
        public double? SemicircunferenciaEscudoEscapular { get; set; }
        public double? ComprimentoEscudoEscapular { get; set; }
        public double? LarguraEscudoCefalico { get; set; }
        public double? ComprimentoEscudoPelvico { get; set; }
        public double? LarguraInterOrbital { get; set; }
        public double? SemicircunferenciaEscudoPelvico { get; set; }
        public double? LarguraInterLacrimal { get; set; }
        public double? LarguraNaSegundaCinta { get; set; }
        public double? ComprimentoMaoSemUnha { get; set; }
        public double? ComprimentoUnhaDaMao { get; set; }
        public double? ComprimentoPeSemUnha { get; set; }
        public double? ComprimentoUnhaDoPe { get; set; }
        public double? ComprimentoPenis { get; set; }
        public double? LarguraBasePenis { get; set; }
        public double? ComprimentoClitoris { get; set; }

        public override string ToString()
        {
            return string.Join("|",
                IdFicha, IdentificacaoAnimal, LocalCaptura, Peso, NumeroMicrochip,
                DataCaptura.ToString("dd/MM/yyyy"), HorarioCaptura.ToString(@"hh\:mm"),
                EquipeResponsavel, Instituicao, ContatoResponsavel,
                ComprimentoTotal, ComprimentoOrelha, NumeroCintas, ComprimentoCabeca, ComprimentoCauda,
                LarguraCabeca, LarguraCauda, PadraoEscudoCefalico, ComprimentoEscudoCefalico,
                SemicircunferenciaEscudoEscapular, ComprimentoEscudoEscapular, LarguraEscudoCefalico,
                ComprimentoEscudoPelvico, LarguraInterOrbital, SemicircunferenciaEscudoPelvico,
                LarguraInterLacrimal, LarguraNaSegundaCinta, ComprimentoMaoSemUnha,
                ComprimentoUnhaDaMao, ComprimentoPeSemUnha, ComprimentoUnhaDoPe, ComprimentoPenis,
                LarguraBasePenis, ComprimentoClitoris);
        }

        public static FichaCadastral FromString(string input)
        {
            try
            {
                string[] parts = input.Split('|');
                return new FichaCadastral
                {
                    IdFicha = int.Parse(parts[0]),
                    IdentificacaoAnimal = parts[1],
                    LocalCaptura = parts[2],
                    Peso = double.Parse(parts[3], CultureInfo.InvariantCulture),
                    NumeroMicrochip = parts[4],
                    DataCaptura = DateTime.ParseExact(parts[5], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    HorarioCaptura = TimeSpan.ParseExact(parts[6], @"hh\:mm", CultureInfo.InvariantCulture),
                    EquipeResponsavel = parts[7],
                    Instituicao = parts[8],
                    ContatoResponsavel = parts[9],
                    ComprimentoTotal = ParseNullableDouble(parts[10]),
                    ComprimentoOrelha = ParseNullableDouble(parts[11]),
                    NumeroCintas = ParseNullableInt(parts[12]),
                    ComprimentoCabeca = ParseNullableDouble(parts[13]),
                    ComprimentoCauda = ParseNullableDouble(parts[14]),
                    LarguraCabeca = ParseNullableDouble(parts[15]),
                    LarguraCauda = ParseNullableDouble(parts[16]),
                    PadraoEscudoCefalico = parts[17],
                    ComprimentoEscudoCefalico = ParseNullableDouble

(parts[18]),
                    SemicircunferenciaEscudoEscapular = ParseNullableDouble(parts[19]),
                    ComprimentoEscudoEscapular = ParseNullableDouble(parts[20]),
                    LarguraEscudoCefalico = ParseNullableDouble(parts[21]),
                    ComprimentoEscudoPelvico = ParseNullableDouble(parts[22]),
                    LarguraInterOrbital = ParseNullableDouble(parts[23]),
                    SemicircunferenciaEscudoPelvico = ParseNullableDouble(parts[24]),
                    LarguraInterLacrimal = ParseNullableDouble(parts[25]),
                    LarguraNaSegundaCinta = ParseNullableDouble(parts[26]),
                    ComprimentoMaoSemUnha = ParseNullableDouble(parts[27]),
                    ComprimentoUnhaDaMao = ParseNullableDouble(parts[28]),
                    ComprimentoPeSemUnha = ParseNullableDouble(parts[29]),
                    ComprimentoUnhaDoPe = ParseNullableDouble(parts[30]),
                    ComprimentoPenis = ParseNullableDouble(parts[31]),
                    LarguraBasePenis = ParseNullableDouble(parts[32]),
                    ComprimentoClitoris = ParseNullableDouble(parts[33])
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao tentar converter a linha em FichaCadastral: " + ex.Message);
                return null;
            }
        }

        static double? ParseNullableDouble(string input)
        {
            return string.IsNullOrWhiteSpace(input) ? null : (double?)double.Parse(input, CultureInfo.InvariantCulture);
        }

        static int? ParseNullableInt(string input)
        {
            return string.IsNullOrWhiteSpace(input) ? null : (int?)int.Parse(input);
        }
    }
}