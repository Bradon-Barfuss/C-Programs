namespace Assignment1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

  
        private void SubmitButton1_Click(object sender, EventArgs e)
        {
         
        }
        private void SeeNameLabel_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// When the Virus Button is Clicked, it will pop up a message box saying you got a virus (But you really did not get one)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VirusButton_Click(object sender, EventArgs e)
        {

            DialogResult MyResult;
            MyResult = MessageBox.Show($"You got a virus! It is the {VirusTextBox.Text} OH NO!! JK, Nothing but ones and zeros here", "VIRUS!!!!!!!!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            VirusTextBox.Text = $"You Clicked: {MyResult}";
        }
  
        /// <summary>
        /// When the temperature button is clicked, it will pop up a message box saying the temperature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TemperatureButton_Click(object sender, EventArgs e)
        {
            DialogResult MyResult;
            MyResult = MessageBox.Show($"IT IS SO COLD RIGHT NOW!! It is: {TemperatureTextBox.Text} Degrees outside!!! That is sooo cold", "Freezing right now", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
            TemperatureTextBox.Text = $"You Clicked: {MyResult}";
        }

        /// <summary>
        /// When the Name button is pressed, a message box will appear displaying your name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameButton_Click(object sender, EventArgs e)
        {
            DialogResult MyResult;
            MyResult = MessageBox.Show($"Hi! Your Name is {NameTextBox.Text}\n", "Your Name Section", MessageBoxButtons.OK, MessageBoxIcon.Information);
            NameTextBox.Text = $"You Clicked: {MyResult}";
        }
    }
}
