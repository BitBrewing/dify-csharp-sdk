using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class UserInputFormOptions
    {
        /// <summary>
        /// 文本输入控件
        /// </summary>
        [JsonPropertyName("text-input")]
        public UserInputFormTextInputOptions TextInput { get; set; }

        /// <summary>
        /// 段落文本输入控件
        /// </summary>
        [JsonPropertyName("paragraph")]
        public UserInputFormParagraphOptions Paragraph { get; set; }

        /// <summary>
        /// 下拉控件
        /// </summary>
        [JsonPropertyName("select")]
        public UserInputFormSelectOptions Select { get; set; }

        /// <summary>
        /// 数字
        /// </summary>
        [JsonPropertyName("number")]
        public UserInputFormNumberOptions Number { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        [JsonIgnore]
        public string Type
        {
            get
            {
                if (TextInput != null)
                    return "text-input";

                if (Paragraph != null)
                    return "paragraph";

                if (Select != null)
                    return "select";

                if (Number != null)
                    return "number";

                return null;
            }
        }
    }

    public abstract class UserInputFormItemOptions
    {
        /// <summary>
        /// 控件展示标签名
        /// </summary>
        [JsonPropertyName("label")]
        public string Label { get; set; }

        /// <summary>
        /// 控件 ID
        /// </summary>
        [JsonPropertyName("variable")]
        public string Variable { get; set; }

        /// <summary>
        /// 是否必填
        /// </summary>
        [JsonPropertyName("required")]
        public bool Required { get; set; }
    }

    public class UserInputFormTextInputOptions : UserInputFormItemOptions
    {
        /// <summary>
        /// 最大长度
        /// </summary>
        [JsonPropertyName("max_length")]
        public int MaxLength { get; set; }
    }

    public class UserInputFormParagraphOptions : UserInputFormItemOptions
    {
        /// <summary>
        /// 最大长度
        /// </summary>
        [JsonPropertyName("max_length")]
        public int? MaxLength { get; set; }
    }

    public class UserInputFormSelectOptions : UserInputFormItemOptions
    {
        /// <summary>
        /// 选项值
        /// </summary>
        [JsonPropertyName("options")]
        public IReadOnlyList<string> Options { get; set; }
    }

    public class UserInputFormNumberOptions : UserInputFormItemOptions
    {

    }
}