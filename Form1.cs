namespace Programa_1
{
    public partial class Form1 : Form
    {
        public List<Proceso> procesos = new List<Proceso>();
        public List<Lote> lotes = new List<Lote>();

        bool mostrado = false;
        int capture;
        int contador;
        int contadorrestante;
        int contadorcap;
        int contadorlotes;

        int reloj1;
        int reloj2;
        int reloj3;
        int segundos;
        int minutos;
        int horas;

        string strsegundos = "0";
        string strminutos = "0";
        string strhoras = "0";
        string lotsegundos = "0";
        string lotminutos = "0";
        string lothoras = "0";

        int resthoras;
        int restminutos;
        int restsegundos;

        int t2segundos;
        int t2minutos;
        int t2horas;
        int t3segundos;
        string t2strsegundos = "0";
        string t2strminutos = "0";
        string t2strhoras = "0";
       
        public bool process1 = true;
        public bool process2 = false;
        public bool process3 = false;

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            contador = 0;
            contadorrestante = 0;
            contadorlotes = 0;
            segundos = 0;
            minutos = 0;
            horas = 0;
            reloj3 = 0;
            textid.Enabled = false;
            textnom.Enabled = false;
            texttime.Enabled = false;
            textnum1.Enabled = false;
            textnum2.Enabled = false;
            comboBox1.Enabled = false;
            agregar.Enabled = false;
            procesamiento.Enabled = false;

        }

        private bool ValidarNumeros(string myString)
        {
            foreach (char element in myString)
            {
                if (!((element >= 48 && element <= 57) || element == 46))
                {
                    return false;
                }
            }
            if (!(myString == ""))
            {
                return true;
            }
            return false;
        }

        private bool ValidarNumerosint(string myString)
        {
            foreach (char element in myString)
            {
                if (!((element >= 48 && element <= 57)))
                {
                    return false;
                }
            }
            if (!(myString == ""))
            {
                return true;
            }
            return false;
        }

        private void Capturar_Click(object sender, EventArgs e)
        {
            if (ValidarNumeros(textpro.Text))
            {
                capture = int.Parse(textpro.Text);
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                textid.Enabled = true;
                textnom.Enabled = true;
                texttime.Enabled = true;
                textnum1.Enabled = true;
                textnum2.Enabled = true;
                comboBox1.Enabled = true;
                agregar.Enabled = true;


            } else
            {
                MessageBox.Show("Sólo se aceptan numeros enteros.");
            }

        }

        public bool ValidarID(int id)
        {
            if (contador == 0)
            {
                return true;
            }
            foreach (Proceso element in procesos)
            {
                if (element.ID == id)
                {
                    return false;
                }
            } return true;
        }

        private void agregar_Click(object sender, EventArgs e)
        {
            if (contador >= capture)
            {
                MessageBox.Show("Procesos insertados agotados.");
            }
            else
            {
                if (ValidarNumeros(textid.Text))
                {
                    if (ValidarID(int.Parse(textid.Text)))
                    {
                        if (ValidarNumerosint(textid.Text) &&
                        ValidarNumerosint(texttime.Text) &&
                        ValidarNumeros(textnum1.Text) &&
                        ValidarNumeros(textnum2.Text))
                        {
                            if(int.Parse(texttime.Text) <= 0 || comboBox1.Text == "" || !validacion_aritmetica(float.Parse(textnum1.Text) , float.Parse(textnum2.Text), comboBox1.Text))
                            {
                                MessageBox.Show("Rellena los recuadros de forma correcta no los puedes dejar vacios o con valores no validos.");
                            }
                            else
                            {
                                procesos.Add(new Proceso(int.Parse(textid.Text), textnom.Text, int.Parse(texttime.Text), float.Parse(textnum1.Text), float.Parse(textnum2.Text), comboBox1.Text));
                                string temp = textnum1.Text + comboBox1.Text + textnum2.Text;
                                string[] row = { textid.Text, textnom.Text, texttime.Text, temp };
                                var listView = new ListViewItem(row);
                                listView1.Items.Add(listView);
                                contador++;
                                textid.Clear();
                                textnom.Clear();
                                texttime.Clear();
                                textnum1.Clear();
                                textnum2.Clear();
                                comboBox1.Text = "";
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Tipo de dato no valido o campo(s) vacios. Intentalo de nuevo.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No puedes repetir el mismo ID. Intentalo de nuevo.");
                    }
                }
                else
                {
                    MessageBox.Show("ID no válido o vacio. Intentalo de nuevo.");
                }
            }
            if(procesos.Count == capture)
            {
                procesamiento.Enabled = true;
            }
        }

        private void tiempo_restante(int tiempo)
        {
            int horas = tiempo / 3600;
            int minutos = (tiempo / 60) - horas;
            int segundos = tiempo - minutos * 60;

            lotsegundos = segundos.ToString();
            lotminutos = minutos.ToString();
            lothoras = horas.ToString();

            if (lotsegundos.Length == 1)
            {
                lotsegundos = "0" + lotsegundos;
            }
            if (lotminutos.Length == 1)
            {
                lotminutos = "0" + lotminutos;
            }
            if (lothoras.Length == 1)
            {
                lothoras = "0" + lothoras;
            }
            if (lotsegundos == "60")
            {
                lotsegundos = "00";
            }
            if (lotminutos == "60")
            {
                lotminutos = "00";
            }
            label9.Text = lothoras + " : " + lotminutos + " : " + lotsegundos;
        }

        public string tiempo_del_proceso(Proceso proceso)
        {
            int horas = proceso.time / 3600;
            int minutos = (proceso.time / 60) - horas;
            int segundos = proceso.time - minutos * 60;

            string lotsegundos = segundos.ToString();
            string lotminutos = minutos.ToString();
            string lothoras = horas.ToString();

            if (lotsegundos.Length == 1)
            {
                lotsegundos = "0" + lotsegundos;
            }
            if (lotminutos.Length == 1)
            {
                lotminutos = "0" + lotminutos;
            }
            if (lothoras.Length == 1)
            {
                lothoras = "0" + lothoras;
            }
            if (lotsegundos == "60")
            {
                lotsegundos = "00";
            }
            if (lotminutos == "60")
            {
                lotminutos = "00";
            }
            return lothoras + " : " + lotminutos + " : " + lotsegundos;
        }

        private void procesamiento_Click(object sender, EventArgs e)
        {
            agregar.Enabled = false;
            Capturar.Enabled = false;
            textpro.Enabled = false;
            textid.Enabled = false;
            textnom.Enabled = false;
            texttime.Enabled = false;
            textnum1.Enabled = false;
            textnum2.Enabled = false;
            comboBox1.Enabled = false;
            procesamiento.Enabled = false;
            int count = 0;
            Proceso proceso = new Proceso(0,"--",0,0,0,"--");
            Proceso proceso1 = new Proceso(0, "--", 0, 0, 0, "--");
            int timeToArmageddon = 0;

            foreach (Proceso element in procesos)
            {
                timeToArmageddon += element.time;
            }

            tiempo_restante(timeToArmageddon);

            if(procesos.Count == 1)
            {
                Lote temp = new Lote(procesos[0], proceso1, proceso);
                lotes.Add(temp);
            }
            else
            {
                for (int i = 1; i < procesos.Count + 1; i++)
                {
                    if (i % 3 == 0)
                    {
                        Lote temp = new Lote(procesos[i - 3], procesos[i - 2], procesos[i - 1]);
                        lotes.Add(temp);
                        count += 3;
                    }
                }
                if (procesos.Count - count == 1)
                {
                    Lote temp = new Lote(procesos[procesos.Count - 1], proceso, proceso1);
                    lotes.Add(temp);
                }
                if (procesos.Count - count == 2)
                {
                    Lote temp = new Lote(procesos[procesos.Count - 2], procesos[procesos.Count - 1], proceso);
                    lotes.Add(temp);
                }
            }
            restsegundos = int.Parse(lotsegundos);
            restminutos = int.Parse(lotminutos);
            resthoras = int.Parse(lothoras);
            timer2.Start();
            timer3.Start();
            proceso_lotes(contadorlotes);
            textBox1.Text = lotes[contadorlotes].proceso1.ID.ToString();
            textBox2.Text = lotes[contadorlotes].proceso1.nombre.ToString();
            textBox3.Text = lotes[contadorlotes].proceso1.time.ToString();
            textBox4.Text = lotes[contadorlotes].proceso1.dato1.ToString();
            textBox5.Text = lotes[contadorlotes].proceso1.signo.ToString();
            textBox6.Text = lotes[contadorlotes].proceso1.dato2.ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            reloj1++;
            if(reloj1 % 10 == 0)
            {
                segundos++;
                strsegundos = segundos.ToString();
            }
            if (minutos == 59 && segundos == 60)
            {
                horas++;
                strhoras = horas.ToString();
                minutos = 0;
            }
            if (segundos == 60)
            {
                minutos++;
                strminutos = minutos.ToString();
                segundos = 0;
            }
            if(strsegundos.Length == 1)
            {
                strsegundos = "0" + strsegundos;
            }
            if (strminutos.Length == 1)
            {
                strminutos = "0" + strminutos;
            }
            if (strhoras.Length == 1)
            {
                strhoras = "0" + strhoras;
            }
            if(strsegundos == "60")
            {
                strsegundos = "00";
            }
            if(strminutos == "60")
            {
                strminutos = "00";
            }
            time.Text = strhoras + " : " + strminutos + " : " + strsegundos;
        }

        public void CalcularRestante()
        {
            restsegundos = restsegundos - t3segundos;
            string str_resthoras = resthoras.ToString();
            string str_restminutos = restminutos.ToString();
            string str_restsegundos = restsegundos.ToString();

            if (str_resthoras.Length == 1)
            {
                str_resthoras = "0" + str_resthoras;
            }
            if (str_restminutos.Length == 1)
            {
                str_restminutos = "0" + str_restminutos;
            }
            if (str_restsegundos.Length == 1)
            {
                str_restsegundos = "0" + str_restsegundos;
            }
            if(int.Parse(str_restsegundos) < 0 && int.Parse(str_restminutos) > 0)
            {
                str_restminutos = (int.Parse(str_restminutos) - 1).ToString();
                str_restsegundos = "59";
            }
            if(int.Parse(str_restminutos) < 0 && int.Parse(str_resthoras) > 0)
            {
                str_resthoras = (int.Parse(str_resthoras) - 1).ToString();
                str_restminutos = "59";
            }
            if((str_resthoras + " : " + str_restminutos + " : " + str_restsegundos) == "00 : 00 : -1")
            {
                restsegundos = 0;
                restminutos = 0;
                resthoras = 0;
                reloj3 = 0;
                reloj2 = 0;
                timer3.Stop();
                timer2.Stop();
                label18.Text = "0";
               
                if(!mostrado)
                {
                    mostrado = true;
                    timer1.Stop();
                    MessageBox.Show("Lote(s) realizados Fin del Programa");
                }
                
            }
            else
            {
                label9.Text = str_resthoras + " : " + str_restminutos + " : " + str_restsegundos;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            reloj2++;
            if (reloj2 % 10 == 0)
            {
                t2segundos++;
                t2strsegundos = t2segundos.ToString();
            }
            if (t2minutos == 59 && t2segundos == 60)
            {
                t2horas++;
                t2strhoras = t2horas.ToString();
                t2minutos = 0;
            }
            if (t2segundos == 60)
            {
                t2minutos++;
                t2strminutos = t2minutos.ToString();
                t2segundos = 0;
            }
            if (t2strsegundos.Length == 1)
            {
                t2strsegundos = "0" + t2strsegundos;
            }
            if (t2strminutos.Length == 1)
            {
                t2strminutos = "0" + t2strminutos;
            }
            if (t2strhoras.Length == 1)
            {
                t2strhoras = "0" + t2strhoras;
            }
            if (t2strsegundos == "60")
            {
                t2strsegundos = "00";
            }
            if (t2strminutos == "60")
            {
                t2strminutos = "00";
            }
            label16.Text = t2strhoras + " : " + t2strminutos + " : " + t2strsegundos;
            CalcularRestante();
            if (lotes.Count > contadorlotes)
            {
                if (process1 == true)
                {
                    if (tiempo_del_proceso(lotes[contadorlotes].proceso1) == label16.Text)
                    {
                        process1 = false;
                        process2 = true;
                        string temp = lotes[contadorlotes].proceso1.dato1.ToString() + lotes[contadorlotes].proceso1.signo.ToString() + lotes[contadorlotes].proceso1.dato2.ToString();
                        string[] row = { (contadorlotes + 1).ToString(), lotes[contadorlotes].proceso1.ID.ToString(), lotes[contadorlotes].proceso1.nombre.ToString(), temp, procesar_operacion(lotes[contadorlotes].proceso1.dato1, lotes[contadorlotes].proceso1.dato2, lotes[contadorlotes].proceso1.signo).ToString(), lotes[contadorlotes].proceso1.time.ToString() };
                        var listView = new ListViewItem(row);
                        listView3.Items.Add(listView);
                        listView2.Items[0].Remove();
                        t2segundos = 0;
                        t2minutos = 0;
                        t2horas = 0;
                        label16.Text = "00 : 00 : 00";
                        t2strsegundos = "0";
                        t2strminutos = "0";
                        t2strhoras = "0";
                        timer2.Stop();
                        timer2.Dispose();
                        reloj2 = 0;
                        timer2.Start();
                        textBox1.Text = lotes[contadorlotes].proceso2.ID.ToString();
                        textBox2.Text = lotes[contadorlotes].proceso2.nombre.ToString();
                        textBox3.Text = lotes[contadorlotes].proceso2.time.ToString();
                        textBox4.Text = lotes[contadorlotes].proceso2.dato1.ToString();
                        textBox5.Text = lotes[contadorlotes].proceso2.signo.ToString();
                        textBox6.Text = lotes[contadorlotes].proceso2.dato2.ToString();
                    }
                }
                else if (process2 == true)
                {
                    if (tiempo_del_proceso(lotes[contadorlotes].proceso2) == label16.Text)
                    {
                        process2 = false;
                        process3 = true;
                        string temp = lotes[contadorlotes].proceso2.dato1.ToString() + lotes[contadorlotes].proceso2.signo.ToString() + lotes[contadorlotes].proceso2.dato2.ToString();
                        string[] row = { (contadorlotes + 1).ToString(), lotes[contadorlotes].proceso2.ID.ToString(), lotes[contadorlotes].proceso2.nombre.ToString(), temp, procesar_operacion(lotes[contadorlotes].proceso2.dato1, lotes[contadorlotes].proceso2.dato2, lotes[contadorlotes].proceso2.signo).ToString(), lotes[contadorlotes].proceso2.time.ToString() };
                        var listView = new ListViewItem(row);
                        listView3.Items.Add(listView);
                        listView2.Items[0].Remove();
                        t2segundos = 0;
                        t2minutos = 0;
                        t2horas = 0;
                        label16.Text = "00 : 00 : 00";
                        t2strsegundos = "0";
                        t2strminutos = "0";
                        t2strhoras = "0";
                        timer2.Stop();
                        timer2.Dispose();
                        reloj2 = 0;
                        timer2.Start();
                        textBox1.Text = lotes[contadorlotes].proceso3.ID.ToString();
                        textBox2.Text = lotes[contadorlotes].proceso3.nombre.ToString();
                        textBox3.Text = lotes[contadorlotes].proceso3.time.ToString();
                        textBox4.Text = lotes[contadorlotes].proceso3.dato1.ToString();
                        textBox5.Text = lotes[contadorlotes].proceso3.signo.ToString();
                        textBox6.Text = lotes[contadorlotes].proceso3.dato2.ToString();
                    }
                }
                else if (process3 == true)
                {
                    if (tiempo_del_proceso(lotes[contadorlotes].proceso3) == label16.Text)
                    {
                        process3 = false;
                        process1 = true;
                        string temp = lotes[contadorlotes].proceso3.dato1.ToString() + lotes[contadorlotes].proceso3.signo.ToString() + lotes[contadorlotes].proceso3.dato2.ToString();
                        string[] row = { (contadorlotes + 1).ToString(), lotes[contadorlotes].proceso3.ID.ToString(), lotes[contadorlotes].proceso3.nombre.ToString(), temp, procesar_operacion(lotes[contadorlotes].proceso3.dato1, lotes[contadorlotes].proceso3.dato2, lotes[contadorlotes].proceso3.signo).ToString(), lotes[contadorlotes].proceso3.time.ToString() };
                        var listView = new ListViewItem(row);
                        listView3.Items.Add(listView);
                        listView2.Items[0].Remove();
                        t2segundos = 0;
                        t2minutos = 0;
                        t2horas = 0;
                        label16.Text = "00 : 00 : 00";
                        t2strsegundos = "0";
                        t2strminutos = "0";
                        t2strhoras = "0";
                        timer2.Stop();
                        timer2.Dispose();
                        reloj2 = 0;
                        timer2.Start();

                        contadorlotes++;
                        if(lotes.Count > contadorlotes)
                        {
                            textBox1.Text = lotes[contadorlotes].proceso1.ID.ToString();
                            textBox2.Text = lotes[contadorlotes].proceso1.nombre.ToString();
                            textBox3.Text = lotes[contadorlotes].proceso1.time.ToString();
                            textBox4.Text = lotes[contadorlotes].proceso1.dato1.ToString();
                            textBox5.Text = lotes[contadorlotes].proceso1.signo.ToString();
                            textBox6.Text = lotes[contadorlotes].proceso1.dato2.ToString();
                            proceso_lotes(contadorlotes);
                        }
                    }
                }
            }
        }

        public bool validacion_aritmetica(float num1, float num2, string op)
        {
            if (op == "/")
            {
                if (num2 == 0)
                {
                    return false;
                }
                return true;
            }
            if (op == "%")
            {
                if (num1 == 0 || num2 == 0)
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        public float procesar_operacion(float num1, float num2, string op)
        {
            if (op == "+")
            {
                return (float)(num1 + num2);
            }
            if (op == "-")
            {
                return (float)(num1 - num2);
            }
            if (op == "*")
            {
                return (float)(num1 * num2);
            }
            if (op == "/")
            {
                return (float)(num1 / num2);
            }
            if (op == "%")
            {
                return (float)(num1 % num2);
            }
            if (op == "^")
            {
                return (float)Math.Pow(num1, num2);
            }
            return 0;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            reloj3++;
            if (reloj3 % 10 == 0)
            {
                t3segundos = 1;
            }else
            {
                t3segundos = 0;
            }
        }

        public void proceso_lotes(int loteactual)
        {
            label17.Text = (contadorlotes + 1).ToString();
            label18.Text = (lotes.Count - contadorlotes).ToString();
            string[] row = { lotes[loteactual].proceso1.ID.ToString(), lotes[loteactual].proceso1.nombre.ToString(), lotes[loteactual].proceso1.time.ToString() };
            string[] row1 = { lotes[loteactual].proceso2.ID.ToString(), lotes[loteactual].proceso2.nombre.ToString(), lotes[loteactual].proceso2.time.ToString() };
            string[] row2 = { lotes[loteactual].proceso3.ID.ToString(), lotes[loteactual].proceso3.nombre.ToString(), lotes[loteactual].proceso3.time.ToString() };
            var listView = new ListViewItem(row);
            listView2.Items.Add(listView);
            listView = new ListViewItem(row1);
            listView2.Items.Add(listView);
            listView = new ListViewItem(row2);
            listView2.Items.Add(listView);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void time_Click(object sender, EventArgs e)
        {

        }
    }
}