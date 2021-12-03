import 'package:flutter/material.dart';
import 'package:online_shop/Themes/custom_themes.dart';
import "package:velocity_x/velocity_x.dart";

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
