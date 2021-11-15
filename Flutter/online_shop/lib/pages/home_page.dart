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
    final dummyList =
        List.generate(20, (index) => ProductDetailModel.productDetails[0]);
    return Scaffold(
      appBar: AppBar(
        title: Text(appName),
      ),
      body: Padding(
          padding: const EdgeInsets.all(16.0),
          child: ListView.builder(
              itemCount: dummyList.length,
              itemBuilder: (context, index) {
                return ProductListView(productDetail: dummyList[index]);
              })),
      drawer: const CustomDrawer(),
    );
  }

  void loadData() async {
    final productJsonData =
        await rootBundle.loadString("assets/files/products.json");
    final decodedJson = jsonDecode(productJsonData);
    var productData = decodedJson["Products"];
    print(productData);
  }
}
