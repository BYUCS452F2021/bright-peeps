(window.webpackJsonp=window.webpackJsonp||[]).push([[11,2,4,5],{241:function(t,e,n){"use strict";var r=n(9),o=n(2),l=n(95),c=n(16),d=n(12),f=n(45),x=n(174),v=n(94),h=n(173),m=n(4),_=n(46),y=n(68).f,w=n(31).f,C=n(15).f,N=n(243).trim,k="Number",I=o.Number,E=I.prototype,A=f(_(E))==k,P=function(t){if(v(t))throw TypeError("Cannot convert a Symbol value to a number");var e,n,r,o,l,c,d,code,f=h(t,"number");if("string"==typeof f&&f.length>2)if(43===(e=(f=N(f)).charCodeAt(0))||45===e){if(88===(n=f.charCodeAt(2))||120===n)return NaN}else if(48===e){switch(f.charCodeAt(1)){case 66:case 98:r=2,o=49;break;case 79:case 111:r=8,o=55;break;default:return+f}for(c=(l=f.slice(2)).length,d=0;d<c;d++)if((code=l.charCodeAt(d))<48||code>o)return NaN;return parseInt(l,r)}return+f};if(l(k,!I(" 0o1")||!I("0b1")||I("+0x1"))){for(var L,O=function(t){var e=arguments.length<1?0:t,n=this;return n instanceof O&&(A?m((function(){E.valueOf.call(n)})):f(n)!=k)?x(new I(P(e)),n,O):P(e)},S=r?y(I):"MAX_VALUE,MIN_VALUE,NaN,NEGATIVE_INFINITY,POSITIVE_INFINITY,EPSILON,isFinite,isInteger,isNaN,isSafeInteger,MAX_SAFE_INTEGER,MIN_SAFE_INTEGER,parseFloat,parseInt,isInteger,fromString,range".split(","),F=0;S.length>F;F++)d(I,L=S[F])&&!d(O,L)&&C(O,L,w(I,L));O.prototype=E,E.constructor=O,c(o,k,O)}},242:function(t,e,n){"use strict";n.r(e);var r={computed:{username:function(){return this.$store.state.username}},methods:{alertUser:function(){alert("Welcome, ".concat(this.username?this.username:"guest","!"))},alertGotcha:function(){alert("Gotcha! The search functionality isn't implemented in the front-end yet!")}}},o=n(44),component=Object(o.a)(r,(function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",{staticClass:"\n    w-full\n    min-h-[40px]\n    max-h-[60px]\n    py-3\n    flex\n    items-center\n    space-x-3\n    bg-gray-900\n    border-b-2 border-green-300\n    text-white\n  "},[n("span",{staticClass:"px-2 flex-none text-3xl hover:text-green-400"},[n("NuxtLink",{attrs:{to:"/"}},[t._v("Bright Peeps")])],1),t._v(" "),n("div",{staticClass:"flex-auto align-text-bottom text-2xl space-x-3 text-gray-300"},[n("NuxtLink",{staticClass:"hover:text-white",attrs:{to:"/authenticate"}},[t._v("authenticate")]),t._v(" "),n("NuxtLink",{staticClass:"hover:text-white",attrs:{to:"/explore"}},[t._v("explore")]),t._v(" "),n("NuxtLink",{staticClass:"hover:text-white",attrs:{to:"/about"}},[t._v("about")])],1),t._v(" "),n("span",{staticClass:"px-2 flex-none flex space-x-2"},[n("input",{staticClass:"\n        flex-auto\n        appearance-none\n        border\n        rounded\n        py-2\n        px-3\n        italic\n        bg-gray-100\n        focus:bg-white\n        text-gray-400\n        focus:text-gray-700\n        leading-tight\n        focus:outline-none\n      ",attrs:{type:"text",placeholder:"Search anyone..."}}),t._v(" "),n("button",{staticClass:"\n        p-2\n        bg-gray-200\n        hover:bg-gray-100\n        active:bg-gray-300\n        rounded\n        text-gray-800\n      ",on:{click:t.alertGotcha}},[n("svg",{staticClass:"h-6 w-6",attrs:{xmlns:"http://www.w3.org/2000/svg",fill:"none",viewBox:"0 0 24 24",stroke:"currentColor"}},[n("path",{attrs:{"stroke-linecap":"round","stroke-linejoin":"round","stroke-width":"2",d:"M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"}})])])]),t._v(" "),n("span",{staticClass:"px-2 flex-none flex space-x-2"},[n("button",{staticClass:"\n        flex\n        space-x-2\n        p-2\n        bg-gray-200\n        hover:bg-gray-100\n        active:bg-gray-300\n        rounded\n        text-gray-800\n      ",on:{click:t.alertUser}},[n("svg",{staticClass:"h-6 w-6",attrs:{xmlns:"http://www.w3.org/2000/svg",fill:"none",viewBox:"0 0 24 24",stroke:"currentColor"}},[n("path",{attrs:{"stroke-linecap":"round","stroke-linejoin":"round","stroke-width":"2",d:"M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z"}})]),t._v(" "),t.username?n("p",[t._v(t._s(t.username))]):t._e()])])])}),[],!1,null,null,null);e.default=component.exports},243:function(t,e,n){var r=n(19),o=n(10),l="["+n(244)+"]",c=RegExp("^"+l+l+"*"),d=RegExp(l+l+"*$"),f=function(t){return function(e){var n=o(r(e));return 1&t&&(n=n.replace(c,"")),2&t&&(n=n.replace(d,"")),n}};t.exports={start:f(1),end:f(2),trim:f(3)}},244:function(t,e){t.exports="\t\n\v\f\r                　\u2028\u2029\ufeff"},245:function(t,e,n){"use strict";n.r(e);var r=n(8),o=(n(52),n(241),n(53)),l=n.n(o),c={props:{id:{type:Number,required:!0,default:4},name:{type:String,required:!0,default:"A Bright Peep"},description:{type:String,required:!0,default:"A description about a bright peep"}},data:function(){return{image:""}},mounted:function(){var t=this;return Object(r.a)(regeneratorRuntime.mark((function e(){var n,r;return regeneratorRuntime.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return n="https://bright-peeps-api.azurewebsites.net/image/peep/"+t.id,e.next=3,l.a.get(n);case 3:200===(r=e.sent).status?t.image=r.data.result[0]?r.data.result[0].imageUrl:"https://bhcoe.org/wp-content/uploads/2019/08/Profile-placeholder-300x300.png":alert("Failed to retrieve data of peep ".concat(t.id,"."));case 5:case"end":return e.stop()}}),e)})))()},methods:{setActiveId:function(){this.$store.state.id=this.id}}},d=n(44),component=Object(d.a)(c,(function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",{staticClass:"max-w-[300px] rounded-md overflow-hidden shadow-md"},[n("NuxtLink",{attrs:{to:"/profile"},nativeOn:{click:function(e){return t.setActiveId.apply(null,arguments)}}},[n("img",{staticClass:"w-full h-[250px]",attrs:{src:t.image,alt:"Peep Profile Image"}})]),t._v(" "),n("div",{staticClass:"px-6 py-4 bg-gray-700 text-gray-300"},[n("NuxtLink",{attrs:{to:"/profile"},nativeOn:{click:function(e){return t.setActiveId.apply(null,arguments)}}},[n("div",{staticClass:"font-bold text-xl mb-2 hover:text-green-400"},[t._v("\n        "+t._s(t.name)+"\n      ")])]),t._v(" "),n("p",[t._v(t._s(t.description))])],1),t._v(" "),t._m(0)],1)}),[function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",{staticClass:"px-6 py-3 flex space-x-4 bg-gray-600"},[n("button",{staticClass:"flex-auto py-2 hover:text-red-400 hover:bg-gray-500 rounded-md"},[t._v("\n      Like\n    ")]),t._v(" "),n("button",{staticClass:"flex-auto py-2 hover:text-blue-400 hover:bg-gray-500 rounded-md"},[t._v("\n      Follow\n    ")])])}],!1,null,null,null);e.default=component.exports},252:function(t,e,n){"use strict";n.r(e);var r={components:{PeepCard:n(245).default},props:{title:{type:String,required:!0,default:"Peeps"},peeps:[]}},o=n(44),component=Object(o.a)(r,(function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",{staticClass:"max-h-500px my-2 py-3 px-1"},[n("div",{staticClass:"\n      mt-2\n      mb-4\n      pb-3\n      text-left text-3xl\n      font-bold\n      border-b-2 border-gray-600\n    "},[t._v("\n    "+t._s(t.title)+"\n  ")]),t._v(" "),n("ul",{staticClass:"px-4 pb-6 flex overflow-y-scroll space-x-4"},t._l(t.peeps,(function(p){return n("li",{key:p.id,staticClass:"flex-none"},[n("PeepCard",{attrs:{id:p.id,name:p.fullName,description:p.shortDescription}})],1)})),0),t._v(" "),n("div",{staticClass:"mt-2 mb-4 border-t-2 border-gray-600"})])}),[],!1,null,null,null);e.default=component.exports},261:function(t,e,n){"use strict";n.r(e);var r=n(8),o=(n(52),n(53)),l=n.n(o),c={components:{PeepCardHorizontalList:n(252).default},data:function(){return{peeps:[]}},mounted:function(){var t=this;return Object(r.a)(regeneratorRuntime.mark((function e(){var n;return regeneratorRuntime.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return"https://bright-peeps-api.azurewebsites.net/peep/",e.next=3,l.a.get("https://bright-peeps-api.azurewebsites.net/peep/");case 3:200===(n=e.sent).status?t.peeps=n.data.result:alert("Failed to retrieve data of peep ".concat(t.id,"."));case 5:case"end":return e.stop()}}),e)})))()}},d=n(44),component=Object(d.a)(c,(function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",[n("Navbar"),t._v(" "),n("div",{staticClass:"w-prose mx-auto p-4 flex-col text-center"},[n("h1",{staticClass:"text-5xl font-bold"},[t._v("Welcome to Bright Peeps")]),t._v(" "),n("PeepCardHorizontalList",{attrs:{title:"All Peeps",peeps:t.peeps}})],1)],1)}),[],!1,null,null,null);e.default=component.exports;installComponents(component,{Navbar:n(242).default})}}]);