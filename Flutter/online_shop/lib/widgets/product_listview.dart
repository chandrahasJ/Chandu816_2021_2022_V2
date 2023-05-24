// ignore_for_file: avoid_print

import 'package:flutter/material.dart';
import 'package:online_shop/Models/product.dart';

class ProductListView extends StatelessWidget {
  final ProductDetail productDetail;

  const ProductListView({Key? key, required this.productDetail})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Card(
      child: ListTile(
        onTap: () => {print("${productDetail.name} was pressed")},
        leading: Image.network(productDetail.image),
        title: Text(productDetail.name),
        subtitle: Text(productDetail.desc),
        trailing: Text(
          "Rs.${productDetail.price.toString()}",
          textScaleFactor: 1.5,
          style: const TextStyle(
              color: Colors.deepPurple, fontWeight: FontWeight.w600),
        ),
      ),
    );
  }
}
