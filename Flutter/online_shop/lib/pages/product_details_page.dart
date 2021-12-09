import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:online_shop/Models/product.dart';
import 'package:online_shop/Themes/custom_themes.dart';
import 'package:velocity_x/velocity_x.dart';

class ProductDetailsPage extends StatelessWidget {
  final ProductDetail productDetail;
  const ProductDetailsPage({Key? key, required this.productDetail})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: CustomThemes.creamColor,
      appBar: AppBar(
        backgroundColor: Colors.transparent,
      ),
      bottomNavigationBar: Container(
        color: Colors.white,
        child: ButtonBar(
          alignment: MainAxisAlignment.spaceBetween,
          buttonPadding: EdgeInsets.zero,
          children: [
            "\$${productDetail.price}".text.bold.xl4.red400.make(),
            ElevatedButton(
                    onPressed: () {},
                    style: ButtonStyle(
                        backgroundColor:
                            MaterialStateProperty.all(CustomThemes.bluishColor),
                        shape:
                            MaterialStateProperty.all(const StadiumBorder())),
                    child: "Add to Cart".text.make())
                .wh(130, 50)
          ],
        ).p16(),
      ),
      body: SafeArea(
        bottom: false,
        child: Column(
          children: [
            Hero(
                    tag: Key(productDetail.id.toString()),
                    child: Image.network(productDetail.image))
                .h40(context),
            Expanded(
                child: VxArc(
              height: 30.0,
              edge: VxEdge.TOP,
              arcType: VxArcType.CONVEY,
              child: Container(
                width: context.screenWidth,
                color: Colors.white,
                child: Column(
                  children: [
                    productDetail.name.text.xl4
                        .color(CustomThemes.bluishColor)
                        .make(),
                    productDetail.desc.text.xl
                        .textStyle(context.captionStyle!)
                        .make(),
                    8.heightBox,
                    "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. "
                        .text
                        .textStyle(context.captionStyle!)
                        .make()
                        .p12(),
                  ],
                ).py64(),
              ),
            ))
          ],
        ),
      ),
    );
  }
}
