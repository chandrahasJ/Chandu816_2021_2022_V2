// ignore_for_file: avoid_print

import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:online_shop/Models/product.dart';
import 'package:online_shop/Themes/custom_themes.dart';
import "package:velocity_x/velocity_x.dart";

class HomePage extends StatefulWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  final String appName = "Online Shop";

  @override
  void initState() {
    super.initState();
    loadData();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: CustomThemes.creamColor,
        body: SafeArea(
          child: Container(
            padding: Vx.m32,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                const ProductHeader(),
                if (ProductDetailModel.productDetails.isNotEmpty)
                  const ProductList().expand()
                else
                  const Center(
                    child: CircularProgressIndicator(),
                  )
              ],
            ),
          ),
        ));
  }

  void loadData() async {
    final productJsonData =
        await rootBundle.loadString("assets/files/products.json");
    final decodedJson = jsonDecode(productJsonData);
    var productData = decodedJson["Products"];
    ProductDetailModel.productDetails = List.from(productData)
        .map<ProductDetail>(
            (productDetail) => ProductDetail.fromMap(productDetail))
        .toList();
    setState(() {});
  }
}

class ProductHeader extends StatelessWidget {
  const ProductHeader({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        "Online Shop".text.xl5.bold.color(CustomThemes.bluishColor).make(),
        "Latest Products".text.xl2.make()
      ],
    );
  }
}

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

class ProductItem extends StatelessWidget {
  final ProductDetail productDetail;
  const ProductItem({Key? key, required this.productDetail}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return VxBox(
        child: Row(
      children: [
        ProductImage(
          imageSrc: productDetail.image,
        ),
        Expanded(
            child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            productDetail.name.text.lg.color(CustomThemes.bluishColor).make(),
            productDetail.desc.text.textStyle(context.captionStyle!).make(),
            10.heightBox,
            ButtonBar(
              alignment: MainAxisAlignment.spaceBetween,
              buttonPadding: EdgeInsets.zero,
              children: [
                "\$${productDetail.price}".text.bold.xl.make(),
                ElevatedButton(
                    onPressed: () {},
                    style: ButtonStyle(
                        backgroundColor:
                            MaterialStateProperty.all(CustomThemes.bluishColor),
                        shape:
                            MaterialStateProperty.all(const StadiumBorder())),
                    child: "Buy".text.make())
              ],
            ).pOnly(right: 8.0)
          ],
        ))
      ],
    )).white.rounded.square(100).make().py16();
  }
}

class ProductImage extends StatelessWidget {
  final String imageSrc;

  const ProductImage({Key? key, required this.imageSrc}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Image.network(imageSrc)
        .box
        .p8
        .rounded
        .color(CustomThemes.creamColor)
        .make()
        .p16()
        .w40(context);
  }
}
