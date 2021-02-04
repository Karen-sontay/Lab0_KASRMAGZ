using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab0_KASRMAGZ.Models.Data;


namespace Lab0_KASRMAGZ.Models
{
    public static class Order
    {
        public static void TryNeed()
        {
            int n = Singleton.Instance.CustomersList.Count;
            int cont = 0;
			int cont1 = 0;
			int cont2 = 0;
			int l, j, aux;
            bool Test = false;

            for (l = 0; l < n - 1; l++)
            {
                for (j = l + 1; j < n; j++)
                {
                    Test = false;
                    string TryName1 = Convert.ToString(Singleton.Instance.CustomersList.Find(x => x.Id == l).Name);
                    string TryName2 = Convert.ToString(Singleton.Instance.CustomersList.Find(x => x.Id == j).Name);
                    var RemoveInfoI = Singleton.Instance.CustomersList.Find(x => x.Id == l);
                    var RemoveInfoJ = Singleton.Instance.CustomersList.Find(x => x.Id == j);

                    while (Test == false)
                    {
                        Test = true;

                        string TryName11 = TryName1.Substring(0, 1);
                        string TryName22 = TryName2.Substring(0, 1);

                        int TryName111 = GetNumber(TryName11);
                        int TryName222 = GetNumber(TryName22);

                        if (TryName111 > TryName222)
                        {
                            //i
                            int IdTryI = Convert.ToInt32(Singleton.Instance.CustomersList.Find(x => x.Id == l).Id);
                            string NameTryI = Convert.ToString(Singleton.Instance.CustomersList.Find(x => x.Id == l).Name);
                            string LastNameI = Convert.ToString(Singleton.Instance.CustomersList.Find(x => x.Id == l).LastName);
                            int TelephoneTryI = Convert.ToInt32(Singleton.Instance.CustomersList.Find(x => x.Id == l).Telephone);
                            string DescriptionTryI = Convert.ToString(Singleton.Instance.CustomersList.Find(x => x.Id == l).Description);

                            //j
                            int IdTryJ = Convert.ToInt32(Singleton.Instance.CustomersList.Find(x => x.Id == j).Id);
                            string NameTryJ = Convert.ToString(Singleton.Instance.CustomersList.Find(x => x.Id == j).Name);
                            string LastNameJ = Convert.ToString(Singleton.Instance.CustomersList.Find(x => x.Id == j).LastName);
                            int TelephoneTryJ = Convert.ToInt32(Singleton.Instance.CustomersList.Find(x => x.Id == j).Telephone);
                            string DescriptionTryJ = Convert.ToString(Singleton.Instance.CustomersList.Find(x => x.Id == j).Description);

                            var UpdateCustumersI = new Models.Customers
                            {
                                Id = IdTryI,
                                Name = NameTryI,
                                LastName = LastNameI,
                                Telephone = TelephoneTryI,
                                Description = DescriptionTryI
                            };

                            var UpdateCustumersj = new Models.Customers
                            {
                                Id = IdTryJ,
                                Name = NameTryJ,
                                LastName = LastNameJ,
                                Telephone = TelephoneTryJ,
                                Description = DescriptionTryJ
                            };

                            Singleton.Instance.CustomersList.Remove(RemoveInfoJ);
                            Singleton.Instance.CustomersList.Remove(RemoveInfoI);
                           Singleton.Instance.CustomersList.Insert(l, UpdateCustumersj);
                            Singleton.Instance.CustomersList.Insert(j, UpdateCustumersI);


                        }
                        else if (TryName111 == TryName222)
                        {
                            int Long1 = TryName1.Length;
                            int Long2 = TryName2.Length;

                            TryName1 = TryName1.Substring(Long1-1,1);
                            TryName2 = TryName2.Substring(Long2-1, 1);
                            Test = false;
                        }
                    }


                }


            }

            int GetNumber(string letter)
            {
                int number = 0;
                switch (letter)
                {
                    case ("A"):
                        number = 1;
                        break;
                    case ("B"):
                        number = 2;
                        break;
                    case ("C"):
                        number = 3;
                        break;
                    case ("D"):
                        number = 4;
                        break;
                    case ("E"):
                        number = 5;
                        break;
                    case ("F"):
                        number = 6;
                        break;
                    case ("G"):
                        number = 7;
                        break;
                    case ("H"):
                        number = 8;
                        break;
                    case ("I"):
                        number = 9;
                        break;
                    case ("J"):
                        number = 10;
                        break;
                    case ("K"):
                        number = 11;
                        break;
                    case ("L"):
                        number = 12;
                        break;
                    case ("M"):
                        number = 13;
                        break;
                    case ("N"):
                        number = 14;
                        break;
                    case ("O"):
                        number = 15;
                        break;
                    case ("P"):
                        number = 16;
                        break;
                    case ("Q"):
                        number = 17;
                        break;
                    case ("R"):
                        number = 18;
                        break;
                    case ("S"):
                        number = 19;
                        break;
                    case ("T"):
                        number = 20;
                        break;
                    case ("U"):
                        number = 21;
                        break;
                    case ("V"):
                        number = 22;
                        break;
                    case ("W"):
                        number = 23;
                        break;
                    case ("X"):
                        number = 24;
                        break;
                    case ("Y"):
                        number = 25;
                        break;
                    case ("Z"):
                        number = 26;
                        break;
                    default:
                        break;
                }

                return number;
            }

            //         for(int i=0; i<n; i++)
            //         {
            //	int aux, l, j;
            //	for (l = 0; l < n - 1; l++)
            //	{
            //		for (j = l + 1; j < n; j++)
            //		{
            //                     int first = Convert.ToInt32(Singleton.Instance.CustomersList.Find(x => x.Id == id));

            //			int second = Convert.ToInt32(Singleton.Instance.CustomersList.Find(x => x.Id + 1== id));

            //			if ((Singleton.Instance.CustomersList.Find(x => x.Id == id)) > Singleton.Instance.CustomersList.Find(x => x.Id == id))
            //			{
            //				aux = Convert::ToInt32(Arreglo[l]);
            //				first = Convert::ToInt32(Arreglo[j]);
            //				Arreglo[j] = aux;

            //			}
            //		}
            //	}
            //}
        }
    }
}
