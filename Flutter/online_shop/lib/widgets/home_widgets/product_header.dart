import 'package:flutter/material.dart';
import "package:velocity_x/velocity_x.dart";

class ProductHeader extends StatelessWidget {
  const ProductHeader({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        // ignore: deprecated_member_use
        "Online Shop".text.xl5.bold.color(context.theme.accentColor).make(),
        "Latest Products".text.xl2.make()
      ],
    );
  }
}
