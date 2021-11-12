class ProductDetailModel {
  static final productDetails = [
    ProductDetail("OS001", "Product 01", "Product Data", 999, "#ffffff",
        "https://retailminded.com/wp-content/uploads/2016/03/EN_GreenOlive-1.jpg")
  ];
}

class ProductDetail {
  final String id;
  final String name;
  final String desc;
  final num price;
  final String color;
  final String image;

  ProductDetail(
      this.id, this.name, this.desc, this.price, this.color, this.image);
}
