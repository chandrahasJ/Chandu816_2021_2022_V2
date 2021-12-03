import 'package:flutter/material.dart';
import 'package:online_shop/Models/product.dart';
import 'package:online_shop/widgets/home_widgets/product_item.dart';

class ProductList extends StatelessWidget {
  const ProductList({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return ListView.builder(
        shrinkWrap: true,
        itemCount: ProductDetailModel.productDetails.length,
        itemBuilder: (context, index) {
          final productDetail = ProductDetailModel.productDetails[index];
          return ProductItem(productDetail: productDetail);
        });
  }
}
