Title: Setting a prop to typeof enum in vue SFC
Published: 7/10/2018
Tags: [vuejs, typescript, quick tips]
---
One of the ways to get typescript support inside single file components is to use [vue-class-component](https://github.com/vuejs/vue-class-component) together with [vue-property-decorator](https://github.com/kaorun343/vue-property-decorator).

This enables you to give better typings for your props:
```ts
import { Vue, Prop, Component } from "vue-property-decorator";

@Component({
    name: 'MyCoolComponent'
})
export default class extends Vue {
    @Prop() complexType!: ComplexType
}
```

But the caveat is that Vue will treat the type as `Object` in most cases.
One place where this can be a problem is when using enums.

With the following code:
```ts
enum Suites {
    Heart = 1,
    Spade = 2,
    Diamond = 3,
    Club = 3
}

...component declaration
@Prop() suite!: Suites;
```

You will get type checking inside you file, but at runtime you may encounter the following error
`[Vue warn]: Invalid prop: type check failed for prop "suite". Expected Object, got Number.`.

This is because under the hood, a typescript enum looks like this ([ts playground link](https://www.typescriptlang.org/play/#src=enum%20Suites%20%7B%0D%0A%20%20%20%20Heart%20%3D%201%2C%0D%0A%20%20%20%20Spade%20%3D%202%2C%0D%0A%20%20%20%20Diamond%20%3D%203%2C%0D%0A%20%20%20%20Club%20%3D%203%0D%0A%7D)):
```ts
var Suites;
(function (Suites) {
    Suites[Suites["Heart"] = 1] = "Heart";
    Suites[Suites["Spade"] = 2] = "Spade";
    Suites[Suites["Diamond"] = 3] = "Diamond";
    Suites[Suites["Club"] = 3] = "Club";
})(Suites || (Suites = {}));
```
and when an enum member is passed into the vue component, it thinks it got a number.

The fix I found was to use the following configuration inside the `Prop` decorator.
```ts
@Prop({ 
    type: Number,
    default: null // Use this if the value can be null or undefined
})
suite!: Suite;
```