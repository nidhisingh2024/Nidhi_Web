<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Assginment_1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        /* Style for labels */
        label {
            display: block;
            margin-bottom: 5px;
        }

        /* Style for textboxes */
        input[type="text"] {
            width: 250px;
            padding: 5px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        /* Style for button */
        input[type="button"] {
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        /* Style for button hover effect */
        input[type="button"]:hover {
            background-color: #0056b3;
        }

        /* Additional styling */
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        form {
            width: 400px;
            margin: 50px auto;
            background-color: burlywood;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h2 {
            color: #007bff;
        }

        /* Style for validation errors */
        .validator-error {
            background-color: #f8d7da; /* Red background */
            border: 1px solid #f5c6cb; /* Red border */
            padding: 5px;
            border-radius: 5px;
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>&nbsp;<center>Validation</center></h2>
            <div style="margin-left: 40px">
                <label for="txtName">Name:</label>
                <asp:TextBox ID="txtName" runat="server" BackColor="#FFFFCC" BorderStyle="Dashed"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="error-message" ID="RequiredFieldValidator" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required" ForeColor="Red">*</asp:RequiredFieldValidator>
            </div>
            <div style="margin-left: 40px">
                <label for="txtFamilyName">Family Name:</label>
                <asp:TextBox ID="txtFamilyName" runat="server" BackColor="#FFFFCC" BorderStyle="Dashed"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="error-message" ID="RequiredFamilyNameValidator" runat="server" ControlToValidate="txtFamilyName" ErrorMessage="Family Name is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:CompareValidator CssClass ="error-message" ID="CompareNameValidator" runat="server" ControlToValidate="txtName" ControlToCompare="txtFamilyName" Operator="NotEqual" ErrorMessage="Name and Family Name should not match"></asp:CompareValidator>
            </div>
            <div style="margin-left: 40px">
                <label for="txtAddress">Address:</label>
                <asp:TextBox ID="txtAddress" runat="server" BackColor="#FFFFCC" BorderStyle="Dashed"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredAddressValidator" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:CustomValidator CssClass="error-message" ID="MinLengthAddressValidator" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address must be at least 2 characters long" ValidateValue="ValidateMinLength" ForeColor="Red">*</asp:CustomValidator>

            </div>
            <div style="margin-left: 40px">
                <label for="txtCity">City:</label>
                <asp:TextBox ID="txtCity" runat="server" BackColor="#FFFFCC" BorderStyle="Dashed"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredCityValidator" runat="server" ControlToValidate="txtCity" ErrorMessage="City is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:CustomValidator CssClass="error-message" ID="MinLengthCityValidator" runat="server" ControlToValidate="txtCity" ErrorMessage="City must be at least 2 characters long" ValidateValue="ValidateMinLength"></asp:CustomValidator>

            </div>
            <div style="margin-left: 40px">
                <label for="txtZipCode">Zip Code:</label>
                <asp:TextBox ID="txtZipCode" runat="server" BackColor="#FFFFCC" BorderStyle="Dashed"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Zip Code is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator CssClass="error-message" ID="regexZipCode" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Zip Code must be 5 digits" ValidationExpression="\d{5}"></asp:RegularExpressionValidator>
    
            </div>
            <div style="margin-left: 40px">
                <label for="txtPhone">Phone:</label>
                <asp:TextBox ID="txtPhone" runat="server" BackColor="#FFFFCC" BorderStyle="Dashed"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone Number is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator CssClass="error-message" ID="PhoneFormatValidator" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone number must be in XX-XXXXXXX or XXX-XXXXXXX format" ValidationExpression="^\d{2,3}-\d{7}$"></asp:RegularExpressionValidator>
            </div>
            <div style="margin-left: 40px">
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" BackColor="#FFFFCC" BorderStyle="Dashed"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator CssClass="error-message" ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+"></asp:RegularExpressionValidator>
            </div>
            <div style="margin-left: 40px">
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <%--<asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" BorderStyle="Solid" />--%>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" BackColor="#FFFF99" ForeColor="Black" Height="40px" Width="99px" />
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            
            </div>
            <div>
                <label id="lblWelcome" runat="server" style="display:none;">Welcome user</label>
                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
