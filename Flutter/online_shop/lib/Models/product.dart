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

final ProductDetails = [ProductDetail("", "", " ", 999, "", "")];
