using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PasswordManager : MonoBehaviour
{
    public TMP_InputField password;
    public TMP_InputField confirmation;
    public Button nextButton;
    private bool passOK;
    private bool confirmationOK;
    private Color okColor = Color.green;
    private Color koColor = Color.red;
    private int nbCar = 0;

    [Header("Textes de contraintes")]
    public TextMeshProUGUI upperConstraint;
    public TextMeshProUGUI lowerConstraint;
    public TextMeshProUGUI digitConstraint;
    public TextMeshProUGUI specialConstraint;
    public TextMeshProUGUI doubleConstraint;
    public TextMeshProUGUI triple7Constraint;
    public TextMeshProUGUI xCarConstraint;
    public TextMeshProUGUI secureConstraint;
    public TextMeshProUGUI max22Constraint;
    
    
    public void OnPasswordChange() {
        Debug.Log(password.text);
        passOK = true;
        passOK &= CheckUpperCase();
        passOK &= CheckLowerCase();
        passOK &= CheckDigit();
        passOK &= CheckSpecialCar();
        passOK &= CheckDoubleCar();
        passOK &= Check777();
        passOK &= CheckXCar();
        passOK &= CheckSecure();
        passOK &= Check22Car();

        nextButton.interactable = (passOK && confirmationOK);
    }

    public void OnConfirmationChange() {
        confirmationOK = (password.text == confirmation.text);
        nextButton.interactable = (passOK && confirmationOK);
    }

    public void OnShowPassword() {
        if (password.contentType == TMP_InputField.ContentType.Standard) {
            password.contentType = TMP_InputField.ContentType.Password;
            confirmation.contentType = TMP_InputField.ContentType.Password;
        } else {
            password.contentType = TMP_InputField.ContentType.Standard;
            confirmation.contentType = TMP_InputField.ContentType.Standard;
        }
        password.ForceLabelUpdate();
        confirmation.ForceLabelUpdate();
    }

    private bool CheckUpperCase() {
        bool result = false;
        if(password.text.ToLower() != password.text) {
            upperConstraint.color = okColor;
            result = true;
        } else {
            upperConstraint.color = koColor;
        }
        return result;
    }

    private bool CheckLowerCase() {
        bool result = false;
        if(password.text.ToUpper() != password.text) {
            lowerConstraint.color = okColor;
            result = true;
        } else {
            lowerConstraint.color = koColor;
        }
        return result;
    }

    private bool CheckDigit() {
        bool result = false;
        if(password.text.IndexOfAny(new char[]{'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'}) >= 0) {
            digitConstraint.color = okColor;
            result = true;
        } else {
            digitConstraint.color = koColor;
        }
        return result;
    }

    private bool CheckSpecialCar() {
        // TODO
        bool result = false;
        if(password.text.ToLower() != password.text) {
            specialConstraint.color = okColor;
            result = true;
        } else {
            specialConstraint.color = koColor;
        }
        return result;
    }

    private bool CheckDoubleCar() {
        bool result = false;
        List<char> chars = new List<char>();
        foreach(char c in password.text.ToCharArray()) {
            if (chars.Contains(c)) {
                doubleConstraint.color = okColor;
                result = true;
            }
            chars.Add(c);
        }
        if (!result) {
            doubleConstraint.color = koColor;
        }
        return result;
    }

    private bool Check777() {
        bool result = false;
        if(password.text.Contains("777")) {
            triple7Constraint.color = okColor;
            result = true;
        } else {
            triple7Constraint.color = koColor;
        }
        return result;
    }

    private bool CheckXCar() {
        bool result = false;
        if (nbCar == 0) {
            nbCar = password.text.Length + 2;
            xCarConstraint.text = "Le mot de passe doit contenir au moins " + nbCar + " caractères";
        }
        if(password.text.Length >= nbCar) {
            xCarConstraint.color = okColor;
            result = true;
        } else {
            xCarConstraint.color = koColor;
        }
        return result;
    }

    private bool CheckSecure() {
        bool result = false;
        if(password.text.Contains("secure")) {
            secureConstraint.color = okColor;
            result = true;
        } else {
            secureConstraint.color = koColor;
        }
        return result;
    }

    private bool Check22Car() {
        bool result = false;
        if(password.text.Length <= 22) {
            max22Constraint.color = okColor;
            result = true;
        } else {
            max22Constraint.color = koColor;
        }
        return result;
    }
}
