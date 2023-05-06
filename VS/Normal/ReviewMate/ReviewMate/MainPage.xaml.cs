using BarcodeScanner.Mobile;
using BarCodeScan = BarcodeScanner.Mobile.Methods;

namespace ReviewMate;

public partial class MainPage : ContentPage
{ 

	public MainPage()
	{
		InitializeComponent();
#if ANDROID
        //BarCodeScan.SetSupportBarcodeFormat(BarcodeScanner.Mobile.BarcodeFormats.QRCode);
#endif
        
    }

    private void CameraView_OnDetected(object sender, BarcodeScanner.Mobile.OnDetectedEventArg e)
    {
        List<BarcodeResult> results = e.BarcodeResults.ToList();

        string result = string.Empty;
        foreach (BarcodeResult resultResult in results)
        {
            result = $" Type : {resultResult.BarcodeType}, Value: { resultResult.DisplayValue} {Environment.NewLine} ";
        }

        Dispatcher.Dispatch(() =>
        {
            lblBarCodeResults.Text = "";
            lblBarCodeResults.Text = result; 
        });
             
    }
}

