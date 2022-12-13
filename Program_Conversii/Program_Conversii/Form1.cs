namespace Program_Conversii
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int b1, b2, intreg, cifre=0;
        float zecimal;
        double rezultat = 0;
        string n16 = "", rezultat16 = "", intreg16 = "", zecimal16 = "", n="", rezultat_zecimal="";
        string[] numar16;
        private void ToBase10()
        {
            int putere = 0;
            if (b1>10)
            {
                for(int i=cifre-1; i>=0; i--)
                {
                    switch (intreg16[i])
                    {
                        case 'A': rezultat += 10 * Convert.ToInt32(Math.Pow(b1, putere)); break;
                        case 'B': rezultat += 11 * Convert.ToInt32(Math.Pow(b1, putere)); break;
                        case 'C': rezultat += 12 * Convert.ToInt32(Math.Pow(b1, putere)); break;
                        case 'D': rezultat += 13 * Convert.ToInt32(Math.Pow(b1, putere)); break;
                        case 'E': rezultat += 14 * Convert.ToInt32(Math.Pow(b1, putere)); break;
                        case 'F': rezultat += 15 * Convert.ToInt32(Math.Pow(b1, putere)); break;
                        default: rezultat += (Convert.ToInt32(intreg16[i])-48) * Convert.ToInt32(Math.Pow(b1, putere)); break;
                    }
                    putere++;
                }
                if(zecimal16!="")
                {
                    putere = -1;
                    for (int i = 0; i <zecimal16.Length; i++)
                    {
                        switch (zecimal16[i])
                        {
                            case 'A': rezultat += 10 * Math.Pow(b1, putere); break;
                            case 'B': rezultat += 11 * Math.Pow(b1, putere); break;
                            case 'C': rezultat += 12 * Math.Pow(b1, putere); break;
                            case 'D': rezultat += 13 * Math.Pow(b1, putere); break;
                            case 'E': rezultat += 14 * Math.Pow(b1, putere); break;
                            case 'F': rezultat += 15 * Math.Pow(b1, putere); break;
                            default: rezultat += (Convert.ToInt32(zecimal16[i]) - 48) * Math.Pow(b1, putere); break;
                        }
                        putere--;
                    }
                }
            }
            else
            {
                int intreg_aux = intreg;
                while (intreg_aux != 0)
                {
                    rezultat += intreg_aux % 10 * Convert.ToInt32(Math.Pow(b1, putere));
                    putere++;
                    intreg_aux /= 10;
                }
                if (zecimal != 0)
                {
                    float zecimal_aux1 = zecimal;
                    putere = cifre * -1;
                    while(cifre != 0)
                    {
                        zecimal_aux1=zecimal_aux1 * 10;
                        cifre--;
                    }
                    int zecimal_aux = Convert.ToInt32(zecimal_aux1);
                    while (zecimal_aux != 0)
                    {
                        rezultat += zecimal_aux%10 * Math.Pow(b1, putere);
                        putere++;
                        zecimal_aux /= 10;
                    }
                    zecimal_aux1 = 0;
                }
            }
        }
        private void FromBase10()
        {
            int intreg_aux = intreg;
            if(b2>10)
            {
                while (intreg_aux != 0)
                {
                    switch(intreg_aux % b2)
                    {
                        case 10: rezultat16 = "A" + rezultat16; break;
                        case 11: rezultat16 = "B" + rezultat16; break;
                        case 12: rezultat16 = "C" + rezultat16; break;
                        case 13: rezultat16 = "D" + rezultat16; break;
                        case 14: rezultat16 = "E" + rezultat16; break;
                        case 15: rezultat16 = "F" + rezultat16; break;
                        default: rezultat16 = Convert.ToString(intreg_aux % b2) + rezultat16; break;
                    }
                    intreg_aux /= b2;
                }
                if (zecimal16 != "")
                {
                    
                }
            }
            else
            {
                int putere = 0;
                while (intreg_aux !=0)
                {
                    rezultat += intreg_aux%b2 * Convert.ToInt32(Math.Pow(10, putere));
                    putere++;
                    intreg_aux /= b2;
                }
                if(zecimal!=0)
                {
                    float zecimal_aux = zecimal;
                    while(zecimal_aux!=0)
                    {
                        rezultat_zecimal += Convert.ToString(Convert.ToInt32(Math.Floor(zecimal_aux * b2)));
                        zecimal_aux = zecimal_aux*b2 - Convert.ToInt32(Math.Floor(zecimal_aux*b2));
                    }
                    
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            rezultat16 = "";
            rezultat_zecimal = "";
            rezultat = 0;
            cifre = 0;
            n = "";
            intreg = 0;
            zecimal = 0;
            intreg16 = "";
            zecimal16 = "";
            
            b1 = int.Parse(textBox2.Text);
            b2 = int.Parse(textBox3.Text);
            if(b1>10)
            {
                n16 = textBox1.Text;
                if(n16.IndexOf('.')>0 || n.IndexOf(',') > 0)
                {
                    numar16 = n16.Split('.', '.', ',');
                    intreg16 = numar16[0];
                    zecimal16 = numar16[1];
                }
                else
                {
                    intreg16 = n16;
                }
                cifre = intreg16.Length;
            }
            else
            {
                n = textBox1.Text;
                if (n.IndexOf('.') > 0 || n.IndexOf(',') > 0)
                {
                    numar16 = n.Split('.', '.', ',');
                    intreg = Convert.ToInt32(numar16[0]);
                    zecimal = float.Parse(numar16[1]);
                    while(zecimal>1)
                    {
                        zecimal /= 10;
                        cifre++;
                    }
                }
                else
                {
                    intreg = Convert.ToInt32(n);
                }
            }
            if (b1==10)
            {
                FromBase10();
            }
            else
            {
                if(b2==10)
                {
                    ToBase10();
                }
                else
                {
                    ToBase10();
                    n = Convert.ToString(rezultat);
                    if (n.IndexOf('.') > 0 || n.IndexOf(',') > 0)
                    {
                        numar16 = n.Split('.', '.', ',');
                        intreg = Convert.ToInt32(numar16[0]);
                        zecimal = float.Parse(numar16[1]);
                        while (zecimal > 1)
                        {
                            zecimal /= 10;
                            cifre++;
                        }
                    }
                    else
                    {
                        intreg = Convert.ToInt32(n);
                    }
                    rezultat = 0;
                    FromBase10();
                }
            }
            label4.Visible = true;
            textBox4.Visible = true;
            if(b2>10)
            {
                textBox4.Text = (rezultat16);
            }
            else
            {
                if(zecimal!=0 && rezultat_zecimal != "")
                {
                    textBox4.Text = Convert.ToString(rezultat)+","+Convert.ToString(rezultat_zecimal);
                }
                else
                {
                    textBox4.Text = Convert.ToString(rezultat);
                }
                
            }
            
        }
    }
}