using System;
using System.Collections.Generic;
using System.Linq;

namespace SIS_Colmado
{
    class MainClass
    {
        /*
        Esta tarea tiene una valor de 5 puntos , debe realizar un pequeño
        sistema para un colmado , donde el colmadero puede agregar los productos
        de su negocio , los productos tienen nombre, precio y cantidad , lo puede
        editar y borrar, también puede mantener los clientes (Solo el nombre) así
        que puede agregar cliente, editarlo y borrarlos.

Por otra parte tiene la función de realizar ventas que le presentara una opción
inicialmente de buscar al cliente introduciendo su nombre, una vez seleccionado
el cliente, el sistema le permitirá buscar los productos disponible por su nombre,
cuando se selecciona un producto pregunta la cantidad que desea de ese producto y
si hay disponibilidad se agrega a la factura y se le pregunta si desea agregar mas
productos o finalizar la venta pero sino tiene la cantidad debe decirle que no tiene
y mostrale la cantidad que tiene , y preguntarle si desea introducir otra cantidad ,
buscar otro producto o cancelar la venta , en caso de que cancele la venta vuelve al
menú principal.

Una vez finalizada la venta debe mostrase por pantalla el nombre del cliente , los
productos que compro , con su cantidad y precio, un subtotal que es el precio por
la cantidad y un total que es la suma de todos los subtotales.

Por ultimo el colmadero tiene una opción en el menú donde puede ver todas la ventas
realizadas por clientes , en esta opción busca al cliente por su nombre una vez seleccionado
el cliente se muestra el listado de todas sus facturas.
             */
        private static List<Products> _Products = new List<Products>();
        private static List<Clients> _Clients = new List<Clients>();

        private static List<Sales> _Sales = new List<Sales>();

        private struct Clients
        {
            public string ClientName { get; set; }
        }
        private struct Products
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }   
        private struct Sales
        {
            public double Price { get; set; }
            public string ClientName { get; set; }
            public double Quantity { get; set; }
            public double Total { get; set; }
            public string Products { get; set; }

        }

        public static void Main(string[] args)
        {
            MenuPrincipal();
        }
        //MENU PRODUCTS
        private static void MenuPrincipal()
        {
            bool exit = false;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t Bienvenido a ITLA MARKET ;) ");
                Console.WriteLine("\t\t\t\t Menu pricipal");
                Console.WriteLine("\t 1.Mantenimiento de productos");
                Console.WriteLine("\t 2.Mantenimiento de clientes");
                Console.WriteLine("\t 3.Realizar Venta");
                Console.WriteLine("\t 4.Exit");
                Console.Write("\t\t Seleccione el numero segun la accion deseada: ");
                int principalMenu = Convert.ToInt32(Console.ReadLine());


                switch (principalMenu)
                {
                    case 1:

                        MenuProducts();
                        Console.ReadKey();
                        break;
                    case 2:

                        MenuClients();
                        Console.ReadKey();
                        break;
                    case 3:
                        MenuSales();
                        Console.ReadKey();
                        break;
                    case 4:
                        exit = true;
                        break;
                }
                if (exit == true)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t Gracias por utilizar este sistema");
                    Console.ReadKey();
                    break;
                }
            }
        }
        //MENU PRODUCTS
        private static void MenuProducts()
        {
            Console.Clear();
            Console.WriteLine("\t\t Seccion de mantenimiento de productos \n");
            Console.WriteLine("\t 1.Agendar nuevo producto ");
            Console.WriteLine("\t 2.Editar producto ");
            Console.WriteLine("\t 3.Listar productos ");
            Console.WriteLine("\t 4.Eliminar producto ");
            Console.WriteLine("\t 5.Volver al Menu Principal ");
            Console.Write("\t\t Seleccione el numero segun la accion deseada: ");

            int MenuProduct = Convert.ToInt32(Console.ReadLine());
            switch (MenuProduct)
            {
                case 1:
                    FormAddProduct();
                    break;
                case 2:
                    FormEditProduct();
                    break;
                case 3:
                    FormShowProduct();
                    break;
                case 4:
                    FormDeleteProduct();
                    break;
                case 5:
                    MenuPrincipal();
                    break;
            }
        }
        //MENU CLIENTS
        private static void MenuClients()
        {
            Console.Clear();
            Console.WriteLine("\n\t Seccion de mantenimiento de clientela \n");
            Console.WriteLine("\t 1.Agendar nuevo cliente ");
            Console.WriteLine("\t 2.Editar cliente ");
            Console.WriteLine("\t 3.Listar clientes ");
            Console.WriteLine("\t 4.Eliminar cliente ");
            Console.WriteLine("\t 5.Volver al Menu Principal ");
            Console.Write("\t\t Seleccione el numero segun la accion deseada: ");

            int MenuClient = Convert.ToInt32(Console.ReadLine());
            switch (MenuClient)
            {
                case 1:
                    FormAddClient();
                    break;
                case 2:
                    FormEditClients();
                    break;
                case 3:
                    FormShowClients();
                    break;
                case 4:
                    FormDeleteClient();
                    break;
                case 5:
                    MenuPrincipal();
                    break;
            }
        }
        //MENU SALES
        private static void MenuSales()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t Seccion de ventas \n");
            Console.WriteLine("\t 1.Realiza una venta ");
            Console.WriteLine("\t 5.Volver al Menu Principal ");
            Console.Write("\t\t Seleccione el numero segun la accion deseada: ");

            int MenuClient = Convert.ToInt32(Console.ReadLine());
            switch (MenuClient)
            {
                case 1:
                    FormAddSale();
                    break;
                case 5:
                    MenuPrincipal();
                    break;
            }
        }
        //METHODS PRODUCTS
        private static void Add<T>(List<T> _List, T Element)
        {
            _List.Add(Element);
        }
        private static void Edit<T>(List<T> _List, int index, T Element)
        {
            _List[index] = Element;
        }
        private static void Delete<T>(List<T> _List, int index)
        {
            _List.RemoveAt(index);
        }

        //FORMS PRODUCTS
        private static void FormAddProduct()
        {
            Console.Write("\t Nombre: ");
            string nameProduct = Console.ReadLine();
            Console.Write("\t Precio: ");
            double priceProduct = Convert.ToDouble(Console.ReadLine());

            Products prod = new Products();

            prod.Name = nameProduct;
            prod.Price = priceProduct;
            Add(_Products, prod);

            if (_Products.Count != 0)
            {
                Console.WriteLine("Producto Guardado Con Exito!!");
            }
            else
            {
                Console.WriteLine(" :( Producto no guardado, verifique e intente nuevamente.");
            }

        }
        private static void FormEditProduct()
        {
            if (_Products.Count == 0)
            {
                Console.WriteLine("\t Lista de productos vacia");
            }
            else
            {
                FormShowProduct();
                Console.Write("\t Seleccione el numero segun el producto que desee editar: ");
                int index = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                Console.WriteLine("\t\t Introduzca los nuevos valores \n ");
                Console.Write("\t Nombre: ");
                string nameProduct = Console.ReadLine();
                Console.Write("\t Precio: ");
                double priceProduct = Convert.ToDouble(Console.ReadLine());

                Products products = new Products();

                products.Name = nameProduct;
                products.Price = priceProduct;

                Edit(_Products, (index - 1), products);
                Console.WriteLine("\t Producto Editado Con Exito!!");
            }
        }
        private static void FormShowProduct()
        {
            if (_Products.Count == 0)
            {
                Console.WriteLine("\t Listado de productos vacia");
            }
            else
            {
                Console.WriteLine("\t\t Listado de productos: ");
                int count = 1;
                foreach (Products Element in _Products)
                {
                    Console.WriteLine(count + " - " + Element.Name + " \t\t\nPrecio: DOP(" + Element.Price + ") .");
                    count++;
                }
            }
        }
        private static void FormDeleteProduct()
        {
            if (_Products.Count == 0)
            {
                Console.WriteLine("\t\t Lista de Productos vacia");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\t Seleccione el producto que desea eliminar \n");
                FormShowProduct();
                int Product = Convert.ToInt32(Console.ReadLine());
                Delete(_Products, (Product - 1));
                Console.WriteLine("\t Producto eliminado! \n");
                FormShowProduct();
                Console.ReadKey();
            }
        }

        //FORMS CLIENTS
        private static void FormAddClient()
        {
            Console.Write("\t Nombre: ");
            string nameClient = Console.ReadLine();

           Clients clients = new Clients();

            clients.ClientName = nameClient;
            Add(_Clients, clients);

            if (_Clients.Count != 0)
            {
                Console.WriteLine("Cliente Guardado Con Exito!!");
            }
            else
            {
                Console.WriteLine(" :( Cliente no guardado, verifique e intente nuevamente.");
            }

        }
        private static void FormEditClients()
        {
            if (_Clients.Count == 0)
            {
                Console.WriteLine("\t Lista de clientes vacia ");
            }
            else
            {
                FormShowProduct();
                Console.Write("\t Seleccione el numero segun el cliente que desee editar: ");
                int index = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                Console.WriteLine("\t\t Introduzca los nuevos valores \n ");
                Console.Write("\t Nombre: ");
                string nameClient = Console.ReadLine();

                Clients clients = new Clients();

                clients.ClientName = nameClient;

                Edit(_Clients, (index - 1), clients);
                Console.WriteLine("\t Cliente Editado Con Exito!!");
            }
        }
        private static void FormShowClients()
        {
            if (_Clients.Count == 0)
            {
                Console.WriteLine("\t Listado de Clientes vacia");
            }
            else
            {
                Console.WriteLine("\t\t Listado de Clientes: ");
                int count = 1;
                foreach (Clients Element in _Clients)
                {
                    Console.WriteLine(count + " - " + Element.ClientName);
                    count++;
                }
            }
        }
        private static void FormDeleteClient()
        {
            if (_Clients.Count == 0)
            {
                Console.WriteLine("\t\t Lista de clientes vacia");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\t Seleccione el cliente que desea eliminar \n");
                FormShowClients();
                int index = Convert.ToInt32(Console.ReadLine());
                Delete(_Clients, (index - 1));
                Console.WriteLine("\t Cliente eliminado! \n");
                FormShowClients();
                Console.ReadKey();
            }
        }


        //MANTENIMIENTO DE VENTAS Y FACTURAS
        private static void AddSale(List<Sales> _List, Sales sale)
        {
            _List.Add(sale);

        }
        private static void ShowSales(List<Sales> Sales_List, Sales sales)
        {
            int count = 1;
            foreach (Sales sale in Sales_List)
            {
                Console.WriteLine(count + " - " + sales.Products);
                count++;
            }
        }

        //FORMS SALES
        private static void FormAddSale()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t --Ventas-- ");

            if (_Clients.Count == 0)
            {
                Console.WriteLine("Lista de clientes vacia");
            }
            else
            {
                //Ingreso y busqueda de clientes

                FormShowClients();
                Console.Write("\n\t Introduzca el nombre del cliente: ");
                string Client_Name = Console.ReadLine();
                var client = _Clients.Find(x => x.ClientName == Client_Name);

                Sales sales = new Sales();

                sales.ClientName = client.ClientName;

                 List<Sales> c = new List<Sales>();
                 c.Add(new Sales() { ClientName = client.ClientName });

                Add(_Sales, sales);

                if (_Clients.Contains(client))
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\t\t\t --productos-- ");

                    if (_Products.Count == 0)
                    {
                        Console.WriteLine("Lista de productos vacia");
                    }
                    else
                    {
                        //Validacion y eleccion de producto exitente
                        Console.Clear();
                        FormShowProduct();

                        Console.Write("\n\t Introduzca el nombre del producto a facturar: ");
                        string product_Name = Console.ReadLine();

                        var product = _Products.Find(x => x.Name == product_Name);

                        //validacion de cantidad (operacion aritmetica)
                        if (_Products.Contains(product))
                        {
                            sales.Price = product.Price;
                            sales.Products = product.Name;
                            // List<Sales> pro = new List<Sales>();
                            // pro.Add(new Sales() { Products = product.Name });


                            Console.Write("\n\t Introduzca la cantidad de unidades a facturar: ");
                            double quantity = Convert.ToDouble(Console.ReadLine());
                            sales.Quantity = quantity;

                            sales.Total = product.Price * quantity;

                            while (true)
                            {
                                Console.WriteLine("\t1. Finalizar venta");
                                Console.WriteLine("\t2. Cancelar venta");
                                Console.Write("\n\t Que desea realizar ? : ");
                                int Menu = Convert.ToInt32(Console.ReadLine());

                               if (Menu == 1)
                                {

                                    Add(_Sales, sales);

                                    Console.Clear();
                                    Console.WriteLine("\n\n \t\t *****************************");
                                    Console.WriteLine("\t\t ********** FACTURA **********");
                                    Console.WriteLine("\t\t *****************************\n");

                                    Console.WriteLine("\t * Productos comprados:");
                                    //ShowSales(_Sales, sales);

                                    int count = 1;
                                    foreach (Sales sale in _Sales)
                                    {
                                        Console.WriteLine(count + " - " + sales.Products + " .");
                                        count++;
                                    }

                                    // Console.WriteLine("\t * Cantidad de Productos comprados: " + sales.Products);
                                    Console.WriteLine("\t * Total a pagar:" + sales.Total);
                                    Console.WriteLine("\t * CLIENTE: " + sales.ClientName);

                                    Console.WriteLine("\n \t GRACIAS POR SU COMPRA EN ITLA MARKET!");
                                    Console.ReadKey();

                                    MenuPrincipal();
                                }
                                else if (Menu == 2) { MenuPrincipal(); }
                            }

                        }
                        else
                        {
                            Console.WriteLine(product.Name);
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Cliente no existente");
                    Console.ReadKey();
                }
            }
        }
        private static void vSale()
        {
        }
           
    }
}
