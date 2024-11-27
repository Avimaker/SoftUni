function solve() {
   // Get element references
   const resultElement = document.querySelector('textarea[disabled]');
   const checkoutButton = document.querySelector('button.checkout');
   // const addButtons = document.querySelectorAll('button.add-product');
   const productCatalogElement = document.querySelector('.shopping-cart');

   let products = [];

   // Attach event for add product
   productCatalogElement.addEventListener('click', (e) => {
      // Event delegation
      if (e.target.tagName !== 'BUTTON') {
         return;
      }

      if (e.target.textContent.trim() !== 'Add') {
         return;
      }

      // Get name and price
      // const productElement = e.target.parentElement.parentElement;
      const productElement = e.target.closest('.product');
      const name = productElement.querySelector('.product-title').textContent;
      const price = Number(productElement.querySelector('.product-line-price').textContent);

      // Print in text area
      resultElement.value += `Added ${name} for ${price.toFixed(2)} to the cart.\n`;

      // Add product to the array
      products.push({
         name,
         price,
      });
   });

   // Attach checkout event
   checkoutButton.addEventListener('click', (e) => {
      // calculate total price // 
      const totalPrice = products.reduce((price, product) => price + product.price, 0);

      // get unique products list comma separated
      const productList = Array.from(new Set(products.map(product => product.name)));

      // Print result in text area
      resultElement.value += `You bought ${productList.join(', ')} for ${totalPrice.toFixed(2)}.`;

      // Dissable all button after checkout
      document.querySelectorAll('button')
         .forEach(el => el.setAttribute('disabled', 'disabled'));
   });
}
