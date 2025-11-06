using System;
using System.Security.Cryptography;
using UnityEngine;

public class IAPRSAValidator : MonoBehaviour
{
    // Paste your Google Play public key here (XML or PEM not needed for Google Play, just the Base64 string)
    public string googlePlayPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAxdXdVfaY+cOTOFkSKgdKbBPsjSg88jo9Qfua9J4EW5zxE9fIth8WZcDs9HWWnVkasKEYZzlSe3VuzBqnaJ7KaqGGskCWzlZ78gNgFM29nQ//PlR5/Odq0ZTHofV/CXw4I7QXZCKAyj3SacQW+7EfnsJ3JXLBhjInY+yBuveastzT/s38JIg95wQvnOF3evu3oKpVS6alLzPQRJWkYoZrXxBFg1BPzh2eV213ChpViwWV+xERhgtpxeQiucG+JqT/oru47B9BPxeXSq2agc9R6O7fKD3umyHbij5gmVZ7upr3e/4VUXejNb0ijkdEjz5xTHDXQu32PdcaRNXF9Z5s+wIDAQAB";

    void Start()
    {
        bool isValid = IsRSAKeyValid(googlePlayPublicKey);
        Debug.Log("RSA Public Key Valid: " + isValid);
    }

    bool IsRSAKeyValid(string publicKey)
    {
        try
        {
            using (RSA rsa = RSA.Create())
            {
                // Google Play public key is Base64, convert to bytes
                byte[] keyBytes = Convert.FromBase64String(publicKey);

                rsa.ImportSubjectPublicKeyInfo(keyBytes, out _);

                // Test encrypt some data to see if key works
                byte[] testData = System.Text.Encoding.UTF8.GetBytes("Test");
                byte[] encrypted = rsa.Encrypt(testData, RSAEncryptionPadding.Pkcs1);

                return encrypted.Length > 0;
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning("RSA Key invalid: " + e.Message);
            return false;
        }
    }
}
