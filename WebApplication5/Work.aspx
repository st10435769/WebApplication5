<%@ Page Title="Our Work" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Work.aspx.cs" Inherits="WebApplication5.Work" %>

<asp:Content ID="Scripts" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        // Initialize cart counter
        var cartCount = 0;

        // Function to increment cart count
        function addToCart(productId) {
            cartCount++;
            document.getElementById('CartCounter').innerHTML = 'Items in Cart: ' + cartCount;
        }

        // Add event listeners to all add to cart buttons
        var addToCartButtons = document.querySelectorAll('.add-to-cart');
        addToCartButtons.forEach(function(button) {
            button.addEventListener('click', function() {
                addToCart(button.getAttribute('data-product-id'));
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $('.add-to-cart').click(function () {
                var productId = $(this).data('product-id');
                var price = $(this).data('price');
                addToCart(productId, price);
            });
        });

        function addToCart(productId, price) {
            // Assuming AJAX call to server to add product to cart
            $.ajax({
                type: 'POST',
                url: 'Work.aspx/AddToCart', // Example of ASP.NET WebMethod to handle this
                data: JSON.stringify({ productId: productId, price: price }),
                contentType: 'application/json; charset=utf-8',
                success: function (response) {
                    alert('Product added to cart!');
                },
                error: function () {
                    alert('Error adding product to cart.');
                }
            });
        }
</script>
<%--</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">--%>
    <h2><%: Title %></h2>
    <h3>Explore our curated collection of artisanal creations, each crafted with passion, skill, and a story to tell.</h3>
    <br />
    
    <div>
        <asp:Label ID="CartCounter" runat="server" Text="Items in Cart: 0" CssClass="cart-counter"></asp:Label>
        <asp:HyperLink ID="CheckoutLink" runat="server" NavigateUrl="~/Checkout.aspx" Text="Checkout" CssClass="checkout-link" Visible="False"></asp:HyperLink>
        <%--<asp:Button ID="CheckoutButton" runat="server" Text="Checkout" OnClick="CheckoutButton_Click" Visible="false" />--%>
    </div>
    
    <table>
        <thead>
            <tr>
                <th></th>
                <th></th>
                <th></th>
                <th></th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><img src="Photos/images1.jpg" alt="Image 1"></td>
                <td>
                    <p>Price: R500.00</p>
                    <p>Description: Handcrafted Ceramic Vase</p>
                    <asp:Button ID="AddToCartButton1" runat="server" Text="Add to Cart" CommandArgument="1" OnClick="AddToCartButton_Click" />
                </td>
                <td><img src="Photos/image2.jpg" alt="Image 2"></td>
                <td>
                    <p>Price: R150.00</p>
                    <p>Description: Handcrafted Wooden Bowl</p>
                    <asp:Button ID="AddToCartButton2" runat="server" Text="Add to Cart" CommandArgument="2" OnClick="AddToCartButton_Click" />
                </td>
                <td><img src="Photos/image3.jpg" alt="Image 3"></td>
                <td>
                    <p>Price: R250.00</p>
                    <p>Description: Handcrafted Glass Sculpture</p>
                    <asp:Button ID="AddToCartButton3" runat="server" Text="Add to Cart" CommandArgument="3" OnClick="AddToCartButton_Click" />
                </td>
                <td><img src="Photos/image4.jpg" alt="Image 4"></td>
                <td>
                    <p>Price: R200.00</p>
                    <p>Description: Handcrafted Metal Wall Art</p>
                    <asp:Button ID="AddToCartButton4" runat="server" Text="Add to Cart" CommandArgument="4" OnClick="AddToCartButton_Click" />
                </td>
                <td><img src="Photos/image5.jpg" alt="Image 5"></td>
                <td>
                    <p>Price: R200.00</p>
                    <p>Description: Handcrafted Wooden Sculpture</p>
                    <asp:Button ID="AddToCartButton5" runat="server" Text="Add to Cart" CommandArgument="5" OnClick="AddToCartButton_Click" />
                </td>
            </tr>
            <tr>
                <td><img src="Photos/image6.jpg" alt="Image 6"></td>
                <td>
                    <p>Price: R500.00</p>
                    <p>Description: Handcrafted Ceramic Plate Set</p>
                    <asp:Button ID="AddToCartButton6" runat="server" Text="Add to Cart" CommandArgument="6" OnClick="AddToCartButton_Click" />
                </td>
                <td><img src="Photos/image67.jpg" alt="Image 7"></td>
                <td>
                    <p>Price: R150.00</p>
                    <p>Description: Handcrafted Wooden Spoon Set</p>
                    <asp:Button ID="AddToCartButton7" runat="server" Text="Add to Cart" CommandArgument="7" OnClick="AddToCartButton_Click" />
                </td>
                <td><img src="Photos/images8.jpg" alt="Image 8"></td>
                <td>
                    <p>Price: R250.00</p>
                    <p>Description: Handcrafted Glass Bottle</p>
                    <asp:Button ID="AddToCartButton8" runat="server" Text="Add to Cart" CommandArgument="8" OnClick="AddToCartButton_Click" />
                </td>
                <td><img src="Photos/images9.jpg" alt="Image 9"></td>
                <td>
                    <p>Price: R200.00</p>
                    <p>Description: Handcrafted Wooden Picture Frame</p>
                    <asp:Button ID="AddToCartButton9" runat="server" Text="Add to Cart" CommandArgument="9" OnClick="AddToCartButton_Click" />
                </td>
                <td><img src="Photos/image10.jpg" alt="Image 10"></td>
                <td>
                    <p>Price: R200.00</p>
                    <p>Description: Handcrafted Ceramic Mug Set</p>
                    <asp:Button ID="AddToCartButton10" runat="server" Text="Add to Cart" CommandArgument="10" OnClick="AddToCartButton_Click" />
                </td>
            </tr>
            <tr>
                <td><img src="Photos/image11.jpg" alt="Image 11"></td>
                <td>
                    <p>Price: R500.00</p>
                    <p>Description: Handcrafted Metal Candle Holder</p>
                    <asp:Button ID="AddToCartButton11" runat="server" Text="Add to Cart" CommandArgument="11" OnClick="AddToCartButton_Click" />
                </td>
                <td><img src="Photos/image12.jpg" alt="Image 12"></td>
                <td>
                    <p>Price: R150.00</p>
                    <p>Description: Handcrafted Wooden Coaster Set</p>
                    <asp:Button ID="AddToCartButton12" runat="server" Text="Add to Cart" CommandArgument="12" OnClick="AddToCartButton_Click" />
                </td>
                <td><img src="Photos/image13.jpg" alt="Image 13"></td>
                <td>
                    <p>Price: R250.00</p>
                    <p>Description: Handcrafted Glass Vase</p>
                    <asp:Button ID="AddToCartButton13" runat="server" Text="Add to Cart" CommandArgument="13" OnClick="AddToCartButton_Click" />
                </td>
                <td><img src="Photos/image14.jpg" alt="Image 14"></td>
                <td>
                    <p>Price: R200.00</p>
                    <p>Description: Handcrafted Wooden Wall Clock</p>
                    <asp:Button ID="AddToCartButton14" runat="server" Text="Add to Cart" CommandArgument="14" OnClick="AddToCartButton_Click" />
                </td>
                <td><img src="Photos/image15.jpg" alt="Image 15"></td>
                <td>
                    <p>Price: R200.00</p>
                    <p>Description: Handcrafted Ceramic Bowl Set</p>
                    <asp:Button ID="AddToCartButton15" runat="server" Text="Add to Cart" CommandArgument="15" OnClick="AddToCartButton_Click" />
                </td>
            </tr>
            <tr>
                <td><img src="Photos/image16.jpg" alt="Image 16"></td>
                <td>
                    <p>Price: R500.00</p>
                    <p>Description: Handcrafted Metal Wall Sculpture</p>
                    <asp:Button ID="AddToCartButton16" runat="server" Text="Add to Cart" CommandArgument="16" OnClick="AddToCartButton_Click" />
                </td>
                <td><img src="Photos/image17.jpg" alt="Image 17"></td>
                <td>
                    <p>Price: R150.00</p>
                    <p>Description: Handcrafted Wooden Serving Tray</p>
                    <asp:Button ID="AddToCartButton17" runat="server" Text="Add to Cart" CommandArgument="17" OnClick="AddToCartButton_Click" />
                </td>
                <td><img src="Photos/image18.jpg" alt="Image 18"></td>
                <td>
                    <p>Price: R250.00</p>
                    <p>Description: Handcrafted Glass Bowl Set</p>
                    <asp:Button ID="AddToCartButton18" runat="server" Text="Add to Cart" CommandArgument="18" OnClick="AddToCartButton_Click" />
                </td>
    <td><img src="Photos/image19.jpg" alt="Image 19"></td>
    <td>
        <p>Price: R200.00</p>
        <p>Description: Handcrafted Wooden Wall Shelf</p>
        <asp:Button ID="AddToCartButton19" runat="server" Text="Add to Cart" CommandArgument="19" OnClick="AddToCartButton_Click" />
    </td>
    <td><img src="Photos/image20.jpg" alt="Image 20"></td>
    <td>
        <p>Price: R200.00</p>
        <p>Description: Handcrafted Ceramic Teapot</p>
        <asp:Button ID="AddToCartButton20" runat="server" Text="Add to Cart" CommandArgument="20" OnClick="AddToCartButton_Click" />
    </td>
</tr>


    </tbody>
</table>

    <asp:Repeater ID="OrdersRepeater" runat="server">
        <ItemTemplate>
            <div>
                <h3><%# Eval("Product_Name") %></h3>
                <p>Price: <%# Eval("Price") %></p>
                <p>Description: <%# Eval("Description") %></p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

