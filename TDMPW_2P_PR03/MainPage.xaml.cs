using Microsoft.Maui.Controls;

namespace TDMPW_2P_PR03;

public partial class MainPage : ContentPage
{
	private int count = 0;
	private double IVA = 1.00;
    double monto;

    public MainPage()
	{
		InitializeComponent();
	}

    private void txtAmount_Completed(object sender, EventArgs e)
    {
		updateTotal();
    }

	private void updateTotal()
	{
		try
		{
			this.monto = Math.Round(double.Parse(this.txtAmount.Text),2);
		}
		catch
		{
			this.monto = 0.0;
		}
		lblIVA.Text = $"${Math.Round(monto * (IVA - 1), 2)}";
		int envio = calcularEnvio();
		lblEnvio.Text = $"${envio}";
		lblTotal.Text = $"${Math.Round(((monto * IVA) + envio), 2)}";
		
	}


    private int calcularEnvio ()
	{
		if(monto <= 100)
		{
			return 200;
		}else if(monto <= 300)
		{
			return 100;
		}
		else
		{
			return 0;
		}
	}

    private void propina10_Clicked(object sender, EventArgs e)
    {
		if (sender is Button)
		{
			Button btn = (Button)sender;
			this.IVA = 1 + (double.Parse(btn.Text.Replace('%','0')) / 1000);
			this.sldTip.Value = (this.IVA - 1) * 100;
		}
		updateTotal();
    }
}

