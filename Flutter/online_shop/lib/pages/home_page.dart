import 'package:flutter/material.dart';
import 'package:online_shop/Models/product.dart';
import 'package:online_shop/widgets/custom_drawer.dart';
import 'package:online_shop/widgets/product_listview.dart';

class HomePage extends StatelessWidget {
  const HomePage({Key? key}) : super(key: key);
  final String appName = "Online Shop";

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
}
