(window.webpackJsonp=window.webpackJsonp||[]).push([[5],{242:function(t,e,n){"use strict";n.r(e);var r={computed:{username:function(){return this.$store.state.username}},methods:{alertUser:function(){alert("Welcome, ".concat(this.username?this.username:"guest","!"))},alertGotcha:function(){alert("Gotcha! The search functionality isn't implemented in the front-end yet!")}}},o=n(44),component=Object(o.a)(r,(function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",{staticClass:"\n    w-full\n    min-h-[40px]\n    max-h-[60px]\n    py-3\n    flex\n    items-center\n    space-x-3\n    bg-gray-900\n    border-b-2 border-green-300\n    text-white\n  "},[n("span",{staticClass:"px-2 flex-none text-3xl hover:text-green-400"},[n("NuxtLink",{attrs:{to:"/"}},[t._v("Bright Peeps")])],1),t._v(" "),n("div",{staticClass:"flex-auto align-text-bottom text-2xl space-x-3 text-gray-300"},[n("NuxtLink",{staticClass:"hover:text-white",attrs:{to:"/authenticate"}},[t._v("authenticate")]),t._v(" "),n("NuxtLink",{staticClass:"hover:text-white",attrs:{to:"/explore"}},[t._v("explore")]),t._v(" "),n("NuxtLink",{staticClass:"hover:text-white",attrs:{to:"/about"}},[t._v("about")])],1),t._v(" "),n("span",{staticClass:"px-2 flex-none flex space-x-2"},[n("input",{staticClass:"\n        flex-auto\n        appearance-none\n        border\n        rounded\n        py-2\n        px-3\n        italic\n        bg-gray-100\n        focus:bg-white\n        text-gray-400\n        focus:text-gray-700\n        leading-tight\n        focus:outline-none\n      ",attrs:{type:"text",placeholder:"Search anyone..."}}),t._v(" "),n("button",{staticClass:"\n        p-2\n        bg-gray-200\n        hover:bg-gray-100\n        active:bg-gray-300\n        rounded\n        text-gray-800\n      ",on:{click:t.alertGotcha}},[n("svg",{staticClass:"h-6 w-6",attrs:{xmlns:"http://www.w3.org/2000/svg",fill:"none",viewBox:"0 0 24 24",stroke:"currentColor"}},[n("path",{attrs:{"stroke-linecap":"round","stroke-linejoin":"round","stroke-width":"2",d:"M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"}})])])]),t._v(" "),n("span",{staticClass:"px-2 flex-none flex space-x-2"},[n("button",{staticClass:"\n        flex\n        space-x-2\n        p-2\n        bg-gray-200\n        hover:bg-gray-100\n        active:bg-gray-300\n        rounded\n        text-gray-800\n      ",on:{click:t.alertUser}},[n("svg",{staticClass:"h-6 w-6",attrs:{xmlns:"http://www.w3.org/2000/svg",fill:"none",viewBox:"0 0 24 24",stroke:"currentColor"}},[n("path",{attrs:{"stroke-linecap":"round","stroke-linejoin":"round","stroke-width":"2",d:"M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z"}})]),t._v(" "),t.username?n("p",[t._v(t._s(t.username))]):t._e()])])])}),[],!1,null,null,null);e.default=component.exports}}]);