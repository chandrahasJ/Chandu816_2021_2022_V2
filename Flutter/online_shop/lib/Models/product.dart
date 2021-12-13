import 'dart:convert';

class ProductDetailModel {
  static List<ProductDetail> productDetails = List.empty();
  //Get productDetails vai ID
  static ProductDetail getById(int id) =>
      // ignore: null_closures
      productDetails.firstWhere((element) => element.id == id, orElse: null);
  //Get ProductDetail by Position
  static ProductDetail getByPosition(int pos) => productDetails[pos];
}

class ProductDetail {
  final int id;
  final String name;
  final String desc;
  final num price;
  final String color;
  final String image;

  ProductDetail(
    this.id,
    this.name,
    this.desc,
    this.price,
    this.color,
    this.image,
  );

  ProductDetail copyWith({
    int? id,
    String? name,
    String? desc,
    num? price,
    String? color,
    String? image,
  }) {
    return ProductDetail(
      id ?? this.id,
      name ?? this.name,
      desc ?? this.desc,
      price ?? this.price,
      color ?? this.color,
      image ?? this.image,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'name': name,
      'desc': desc,
      'price': price,
      'color': color,
      'image': image,
    };
  }

  factory ProductDetail.fromMap(Map<String, dynamic> map) {
    return ProductDetail(
      map['id'],
      map['name'],
      map['desc'],
      map['price'],
      map['color'],
      map['image'],
    );
  }

  String toJson() => json.encode(toMap());

  factory ProductDetail.fromJson(String source) =>
      ProductDetail.fromMap(json.decode(source));

  @override
  String toString() {
    return 'ProductDetail(id: $id, name: $name, desc: $desc, price: $price, color: $color, image: $image)';
  }

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;

    return other is ProductDetail &&
        other.id == id &&
        other.name == name &&
        other.desc == desc &&
        other.price == price &&
        other.color == color &&
        other.image == image;
  }

  @override
  int get hashCode {
    return id.hashCode ^
        name.hashCode ^
        desc.hashCode ^
        price.hashCode ^
        color.hashCode ^
        image.hashCode;
  }
}
