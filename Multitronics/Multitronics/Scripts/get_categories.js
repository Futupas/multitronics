/**
 * Скрипт отправляет GET запрос по адресу "/GetCategories",
 * получает JSON списка категорий,
 * отображает их в виде кнопок.
 *
 * По нажатию на любую из кнопок отправляет GET по адресу "/ProductsData?Category=XXX",
 * где XXX - ID нужной категории (XXX = name кнопки),
 * полученный ответ на данном этапе выводится в консоль.
 *
 * @requires vue@2.2.4.js
 * @requires vue-resource.min.js
 *
 * Тестировал на:
 *...
 *<div id="nav">
 *  <button v-for="(cat, index) in categories" :name="index" @click="catBtnOnClick">
 *     {{ cat }}
 *</button>
 *</div>
 * ...
 * */

'use strict';

let nav = new Vue({
	el: '#nav',
	data: {
		/* Категории по умолчанию */
		defCat: {
			defCat1: "def-cat1-value",
			defCat2: "def-cat2-value",
			defCat3: "def-cat3-value",
			defCat4: "def-cat4-value"
		},
		categories: this.defCat,
	},
	methods: {
		/* Выполняется, если результат запроса - ошибка */
		getCatError: function () {
			this.categories = this.defCat;
		},
		/**
		 * @description Запрос методом GET, результат присваивается this.categories
		 * @return DOM
		 * */
		getCat: function () {
			this.$http.get('/GetCategories')
				.then((response) => {
					this.categories = response.body;
				})
				.catch(this.getCatError);
		},
		/**
		 * @description Обработчик нажатия на кнопку "Категория"
		 * @return DOM
		 * */
		catBtnOnClick: function (event) {
			console.log(event.target.name);
			this.$http.get('/ProductsData?Category=' + event.target.name)
			/**
			 * @todo Результат запроса следует присвоить переменной, влияющей на представление продуктов, пока - в консоль.
			 * */
				.then((response) => {
					console.log(response.body);
				}).bind(this)
				.catch(console.log(`No response for request /ProductsData?Category='${(event.target.name)}`));
		}
	}
});
nav.getCat();