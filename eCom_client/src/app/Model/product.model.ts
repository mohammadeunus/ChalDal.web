export interface Product {
  id: number;
  name: string;
  price: number;
  vat: number;
  description: string;
  category: string; // e.g., Fruits, Vegetables, Dairy, Meat, etc.
  imageUrl: string; // URL to the product image
  quantity: number; // Available quantity in stock
  expirationDate: Date; // Expiration date of the product
  lastUpdated: Date;
  updatedBy: string;
  createdBy: string;
}
