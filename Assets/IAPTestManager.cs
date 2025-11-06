//using UnityEngine;
//using UnityEngine.Purchasing;
//using UnityEngine.Purchasing.Security;

//public class IAPTestManager : MonoBehaviour, IStoreListener
//{
//    private IStoreController controller;
//    private IExtensionProvider extensions;

//    [Header("Enter your product ID from Play Console")]
//    public string testProductId = "your_product_id";

//    void Start()
//    {
//        // ✅ Configure Unity IAP
//        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
//        builder.AddProduct(testProductId, ProductType.Consumable);

//        UnityPurchasing.Initialize(this, builder);
//    }

//    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
//    {
//        this.controller = controller;
//        this.extensions = extensions;
//        Debug.Log("IAP initialized successfully!");
//    }

//    public void OnInitializeFailed(InitializationFailureReason error)
//    {
//        Debug.LogError("IAP Init Failed: " + error);
//    }

//    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
//    {
//        Debug.LogError($"Purchase failed: {failureDescription.message}");
//    }

//    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
//    {
//        Debug.Log("Purchase completed: " + args.purchasedProduct.definition.id);

//        // ✅ Receipt validation
//        try
//        {
//            var validator = new CrossPlatformValidator(
//                GooglePlayTangle.Data(),
//                AppleTangle.Data(),
//                Application.identifier);

//            var result = validator.Validate(args.purchasedProduct.receipt);

//            foreach (IPurchaseReceipt receipt in result)
//            {
//                Debug.Log("Validated receipt for: " + receipt.productID);
//            }
//        }
//        catch (IAPSecurityException)
//        {
//            Debug.LogError("Receipt validation failed!");
//            return PurchaseProcessingResult.Complete;
//        }

//        return PurchaseProcessingResult.Complete;
//    }

//    // 👉 Manually trigger a test purchase
//    public void BuyTestProduct()
//    {
//        if (controller != null)
//        {
//            controller.InitiatePurchase(testProductId);
//        }
//        else
//        {
//            Debug.LogError("IAP not initialized yet!");
//        }
//    }
//}
