// ignore_for_file: avoid_print

import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:online_shop/Models/product.dart';
import 'package:online_shop/widgets/custom_drawer.dart';
import 'package:online_shop/widgets/product_listview.dart';

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
      appBar: AppBar(
        title: Text(appName),
      ),
      body: Padding(
          padding: const EdgeInsets.all(16.0),
          child: (ProductDetailModel.productDetails.isNotEmpty)
              ? ListView.builder(
                  itemCount: ProductDetailModel.productDetails.length,
                  itemBuilder: (context, index) {
                    return ProductListView(
                        productDetail:
                            ProductDetailModel.productDetails[index]);
                  })
              : const Center(
                  child: CircularProgressIndicator(),
                )),
      drawer: const CustomDrawer(),
    );
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
