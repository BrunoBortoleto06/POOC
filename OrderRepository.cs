using POOC.Domain.OrderManagement;

namespace POOC;

public class OrderRepository
{

    public string path = @"C:\Users\E5659\Documents\C#\POOC\order.txt";

    public bool FileExist()
    {
        return File.Exists(path);
    }

    public void SaveOrdersToFile(List<Order> orders)
    {
        string conteudo = "";

        foreach (var order in orders)
        {
            string itensTexto = "";

            foreach (var item in order.OrderItems)
            {
                itensTexto += $"{item.Id};{item.ProductID};{item.ProductName};{item.AmountOrdered}|";
            }

            if (itensTexto.EndsWith("|"))
            {
                itensTexto = itensTexto.TrimEnd('|');
            }

            conteudo += $"{order.Id},{order.OrderFulfilmentDate},{order.FulFilled},{itensTexto}\n";
        }

        File.WriteAllText(path, conteudo);
    }

    public List<Order> LoadOrdersFromFile()
    {
        List<Order> orders = new();

        if (!FileExist())
        {
            Console.WriteLine("Arquivo nao existe");
            return orders;
        }

        string[] linhas = File.ReadAllLines(path);

        foreach (string linha in linhas)
        {
            if (string.IsNullOrWhiteSpace(linha)) continue;

            string[] dados = linha.Split(',');

            int id = int.Parse(dados[0].Trim());
            DateTime orderFulfimentDate = DateTime.Parse(dados[1].Trim());
            bool fulFilled = bool.Parse(dados[2].Trim());

            List<OrderItem> listaDeItens = new List<OrderItem>();
            string itensTexto = dados[3].Trim();

            if (!string.IsNullOrEmpty(itensTexto))
            {
                string[] arrayDeItensTexto = itensTexto.Split('|');

                foreach (string itemString in arrayDeItensTexto)
                {

                    string[] dadosItem = itemString.Split(';');

                    OrderItem novoItem = new OrderItem()
                    {
                        Id = int.Parse(dadosItem[0]),
                        ProductID = int.Parse(dadosItem[1]),
                        ProductName = dadosItem[2],
                        AmountOrdered = int.Parse(dadosItem[3])
                    };

                    listaDeItens.Add(novoItem);
                }
            }

            Order novoPedido = new Order()
            {
                Id = id,
                OrderFulfilmentDate = orderFulfimentDate,
                FulFilled = fulFilled,
                OrderItems = listaDeItens
            };

            orders.Add(novoPedido);
        }

        return orders;
    }

}
