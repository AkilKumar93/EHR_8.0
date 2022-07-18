(function ($) {
    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
              .addClass("custom-combobox input-group")
              .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
              value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
              .appendTo(this.wrapper)
              .val(value)
              .addClass("custom-combobox-input")
              .autocomplete({
                  delay: 0,
                  minLength: 0,
                  source: $.proxy(this, "_source"),
                  focus: function (event, ui) {
                      return false;
                  }
              }).width($(this.wrapper).width()-78).attr("placeholder", this.options.placeholder).addClass("form-control");

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                   
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {
            var input = this.input,
              wasOpen = false;

            $("<span>")
              .attr("tabIndex", -1)
              .attr("title", "Show All Items")
              .appendTo(this.wrapper)
              .addClass("input-group-addon custom-combobox-toggle")
              .mousedown(function () {
                  wasOpen = input.autocomplete("widget").is(":visible");
              })
              .click(function () {
                  if (input.prop("disabled") == false) {
                      input.focus();

                      // Close if already visible
                      if (wasOpen) {
                          return;
                      }

                      // Pass empty string as value to search for, displaying all results
                      input.autocomplete("search", "");
                  }
              })
              .append("<i class='glyphicon glyphicon-triangle-bottom'>");
        },

        _source: function (request, response) {
            if (this.element.children("option:disabled").length == 1 && this.element.children("option:disabled").val() == 'No records')
                $(this.input).attr("placeholder", this.element.children("option:disabled").text());

            response(this.element.children("option").map(function () {
                var text = $(this).text();
                var value = $(this).val();
                var match = true;
                if (!this.disabled) {
                    arrayOfTerms = request.term.split(" ");
                    for (var i = 0; i < arrayOfTerms.length && arrayOfTerms[i] != ""; i++) {
                        if (text.toLowerCase().indexOf(arrayOfTerms[i].toLowerCase()) == -1) {
                            match = false;
                            break;
                        }
                    }
                }
                else
                    match = false;
                if (match)
                    return {
                        label: text,
                        value: value,
                        option: this
                    };
            }));
        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item || this.options.bAllowUserInputValues) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
              valueLowerCase = value.toLowerCase(),
              valid = false;
            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {
                return;
            }

        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });
})(jQuery);