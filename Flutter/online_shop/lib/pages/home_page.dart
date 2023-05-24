// ignore_for_file: avoid_print

import 'dart:convert';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:online_shop/Models/product.dart';
import 'package:online_shop/routes/app_route.dart';
import 'package:online_shop/widgets/home_widgets/product_header.dart';
import 'package:online_shop/widgets/home_widgets/product_list.dart';
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
        backgroundColor: context.canvasColor,
        floatingActionButton: FloatingActionButton(
          // ignore: deprecated_member_use
          backgroundColor: context.theme.buttonColor,
          onPressed: () => Navigator.pushNamed(context, CustomRoutes.cartRoute),
          child: const Icon(CupertinoIcons.cart),
        ),
        body: SafeArea(
          child: Container(
            padding: Vx.m32,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                const ProductHeader(),
                if (ProductDetailModel.productDetails.isNotEmpty)
                  const ProductList().py16().expand()
                else
                  const CircularProgressIndicator().centered().expand()
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
